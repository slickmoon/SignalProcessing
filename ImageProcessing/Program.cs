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
            string bitmappath3 = @".\Assets\angerycat.bmp";

            while(!Globals.EXIT_REQUESTED)
            {
                Globals.MAIN_REQUESTED = false;
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
                        Globals.EXIT_REQUESTED = true;
                        break;
                    default: 
                        break;
                }

                if(!Globals.EXIT_REQUESTED && !Globals.MAIN_REQUESTED)
                {
                    BitmapRenderer renderer = new BitmapRenderer(path);
                    renderer.Run();
                }

            }

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }
    }
}
