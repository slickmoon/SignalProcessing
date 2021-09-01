using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AudioProcessing
{
    class Program
    {

        static void Main()
        {
            AudioRenderer render = new AudioRenderer(256f);
            Window window = new Window();
            //float increment = 0.01;
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine(render.GetPointRelative((float)i));
            }
            byte[] wave = render.GetWaveformBytes(8000,1);
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();

            window.Resize += (sender, args) =>
            {
                window.Buffer = BufferedGraphicsManager.Current.Allocate(window.Graphics, new Rectangle(0, 0, window.Width, window.Height));
                window.Buffer.Graphics.Clear(Color.Black);
                window.Update();

                for (int x = 0; x < window.Width - 1; x++)
                {
                    float y = render.GetPointRelative(x) * (window.Height / 2) + (window.Height / 2);
                    float y2 = render.GetPointRelative(x + 1) * (window.Height / 2) + (window.Height / 2);
                    window.Buffer.Graphics.DrawLine(new Pen(Color.Red, 1f), x, y, x + 1, y2);
                }
            };

            while (!window.IsDisposed)
            {
                window.Update();
            }

        }
    }
}