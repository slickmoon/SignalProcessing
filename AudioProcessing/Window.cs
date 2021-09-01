using System;
using System.Drawing;
using System.Windows.Forms;

namespace AudioProcessing
{
    public class Window : Form
    {
        public Graphics Graphics;
        public BufferedGraphics Buffer;

        public Window()
        {
            Show();
            Graphics = CreateGraphics();
            Buffer = BufferedGraphicsManager.Current.Allocate(Graphics, new Rectangle(0, 0, Width, Height));
            Buffer.Graphics.Clear(Color.Black);
        }

        public void Update()
        {
            Application.DoEvents();
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Render(Graphics);
        }
    }
}
