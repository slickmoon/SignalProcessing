using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
                        OutputBitmap();
                        break;
                    case "4":
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
            for(int x = 0; x <= inputbitmap.Width; x++)
            {
                for(int y = 0; y <= inputbitmap.Height; y++)
                {
                    Color pixel = inputbitmap.GetPixel(x, y);
                    Color newpixel = Color.FromArgb(pixel.ToArgb() ^ 0xffffff);
                    inputbitmap.SetPixel(x,y,newpixel);
                    
                }
            }
        }
        private void OutputBitmap()
        {
            inputbitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\outputfile.bmp");
        }
    }
}
