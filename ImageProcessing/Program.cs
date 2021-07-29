using System;
using System.Drawing;
namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up...");

            // Load in assets
            string menutext = System.IO.File.ReadAllText(@".\Assets\Menu.txt");
            string bitmappath1 = @".\Assets\einsteinsmall.bmp";
            string bitmappath2 = @".\Assets\einsteinbig.bmp";
            string bitmappath3 = @".\Assets\einsteinangerycat.bmp";

            bool exitrequested = false;
            while(!exitrequested)
            {
                Console.WriteLine(menutext);
                string menuchoice = Console.ReadLine();
                string path = "";
                switch (menuchoice)
                {
                    case "1":
                        path = bitmappath1;
                        break;
                    case "2":
                        path = bitmappath2;
                        break;
                    case "3":
                        path = bitmappath3;
                        break;
                    case "4":
                        exitrequested = true;
                        break;
                    default: 
                        break;
                }

                if(!exitrequested)
                {
                    BitmapRenderer renderer = new BitmapRenderer(path);
                    renderer.Render();
                }

            }

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }
    }
}
