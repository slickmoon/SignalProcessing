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
        [STAThread]
        static void Main()
        {
            SaveFileDialog s = new SaveFileDialog();
            while (s.ShowDialog() == DialogResult.Yes)
            {
            }

        }
    }
}