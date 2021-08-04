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
    }
}
