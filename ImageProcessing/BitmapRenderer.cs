using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    class BitmapRenderer
    {
        Bitmap inputbitmap;
        string rendertext;
        public BitmapRenderer(string bitmappath)
        {
            try
            {
                Console.WriteLine("Loading file {0}",bitmappath);
                inputbitmap = new Bitmap(bitmappath);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message + e.InnerException.Message);    
            }
            rendertext = System.IO.File.ReadAllText(@".\Assets\Render.txt");

        }

        public void Run()
        {
            while (!Globals.MAIN_REQUESTED)
            {
                Console.WriteLine(rendertext);
                string menuchoice = Console.ReadLine();
                switch (menuchoice)
                {
                    case "1":
                        GetPixelValue();
                        break;
                    case "2":
                        InvertColors();
                        break;
                    case "3":
                        InvertColorsMemoryAccess();
                        break;
                    case "4":
                        OutputBitmap();
                        break;
                    case "5":
                        Globals.MAIN_REQUESTED = true;
                        break;
                    default:
                        break;
                }
            }
        }


        public void GetPixelValue() 
        {
            int xin = 0;
            int yin = 0;

            Console.Write("x value: ");
            Int32.TryParse(Console.ReadLine(), out xin);
            Console.Write("y value: ");
            Int32.TryParse(Console.ReadLine(), out yin);

            Console.WriteLine("Getting pixel {0},{1}", xin, yin);

            if (inputbitmap != null)
            {
                byte value = (byte)(inputbitmap.GetPixel(xin, yin).GetBrightness() * 255);
                //inputbitmap.SetPixel(xin, yin, Color.FromArgb(~value, ~value, ~value));
                Console.WriteLine(value);
            }

        }

        public void InvertColors() 
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int x = 0; x <= inputbitmap.Width-1; x++)
            {
                for(int y = 0; y <= inputbitmap.Height-1; y++)
                {
                    Color pixel = inputbitmap.GetPixel(x, y);
                    Color newpixel = Color.FromArgb(pixel.ToArgb() ^ 0xffffff);
                    inputbitmap.SetPixel(x,y,newpixel);
                    
                }
            }

            watch.Stop();

            Console.WriteLine($"GetPixel Execution Time: {watch.ElapsedMilliseconds} ms");
        }


        public void InvertColorsMemoryAccess()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            unsafe
            {
                BitmapData bitmapData = inputbitmap.LockBits(new Rectangle(0, 0, inputbitmap.Width, inputbitmap.Height), ImageLockMode.ReadWrite, inputbitmap.PixelFormat);
                int bytesPerPixel = Bitmap.GetPixelFormatSize(inputbitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;


                for (int y = 0; y < heightInPixels - 1; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                    {
                        int oldBlue = currentLine[x];
                        int oldGreen = currentLine[x + 1];
                        int oldRed = currentLine[x + 2];

                        // calculate new pixel value
                        currentLine[x] = (byte)oldBlue;
                        currentLine[x + 1] = (byte)oldGreen;
                        currentLine[x + 2] = (byte)oldRed;

                    }
                }
                inputbitmap.UnlockBits(bitmapData);
            }


            watch.Stop();

            Console.WriteLine($"Unsafe direct memory access Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private void OutputBitmap()
        {
            inputbitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\outputfile.bmp");
        }
    }
}
