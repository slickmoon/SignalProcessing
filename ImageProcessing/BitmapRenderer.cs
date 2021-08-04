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
                        Render();
                        break;
                    case "2":
                        InvertColors(new Color());
                        break;
                    case "3":
                        OutputBitmap(inputbitmap);
                        break;
                    case "4":
                        Globals.MAIN_REQUESTED = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public void Render()
        {
            int xin = 0;
            int yin = 0;

            Console.Write("x value: ");
            Int32.TryParse(Console.ReadLine(), out xin);
            Console.Write("y value: ");
            Int32.TryParse(Console.ReadLine(), out yin);

            Console.WriteLine("Getting pixel {0},{1}",xin,yin);

            if(inputbitmap != null)
            {
                byte value = GetPixelValue(xin, yin);
                inputbitmap.SetPixel(xin, yin, Color.FromArgb(~value, ~value, ~value));
                Console.WriteLine(value);
            }

            Console.ReadKey();
            
        }


        public byte GetPixelValue(int x, int y) 
        {
            return (byte)(inputbitmap.GetPixel(x, y).GetBrightness() * 255);
        }

        public Color InvertColors(Color input) 
        {
            return Color.FromArgb(input.ToArgb() ^ 0xffffff);
        }
        private void OutputBitmap(Bitmap image)
        {
            image.Save("C://outputfile.bmp");
        }
    }
}
