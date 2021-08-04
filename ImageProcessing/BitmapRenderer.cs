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

        public void Run()
        {

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
                float value = GetPixelValue(xin, yin);
                Console.WriteLine(value);
            }
            Console.ReadKey();
            
        }

        public float GetPixelValue(int x, int y) 
        {
            return inputbitmap.GetPixel(x, y).GetBrightness();
        }

        private void OutputBitmap(Bitmap image)
        {
            image.Save("C://outputfile.bmp");
        }

    }
}
