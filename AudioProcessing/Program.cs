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
            //SaveFileDialog s = new SaveFileDialog();
            //while (s.ShowDialog() == DialogResult.Yes)
            //{
            //}
            
            byte[] wavebytes = ReadWav(@".\data\sine.wav");
            
            foreach(byte b in wavebytes)
            {
                Console.WriteLine("\n{0}: char = {1}",b.ToString(),(char) b);
                Console.ReadKey();
            }
            
            
            AudioRenderer renderer = new AudioRenderer(4000);
            byte[] waveformbytes = renderer.GetWaveformBytes(8000,1);


            //Generate WAV file
            //WriteWav(waveformbytes, "d:\\output.wav");

            Console.ReadKey();

        }

        /*private static void WriteWav(byte[] pcmbytes,string filepath)
        {
            //write header
            string header = "";
            header += "RIFF";
            header += 



            foreach(byte b in header)
            {
                Console.WriteLine("\n{0}", b.ToString());
                Console.ReadKey();
            }
        }
        */


        private static byte[] ReadWav(string filepath)
        { 
            return System.IO.File.ReadAllBytes(filepath);
        }
    }
}