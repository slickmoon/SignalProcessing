using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    class SineRenderer : RendererBase
    {

        public SineRenderer(float f, float a = 1f, float p = 0f, float o = 0f, float i = 1f) : base (f,a,p,o,i)
        {
            
        }

        public SineRenderer() : base ()
        { 
        }
        
        public override float GetPoint(float t)
        {
            float output = 0f;
            float angFrequency = 2 * (float)Math.PI * Frequency;
            output = Amplitude * (float)Math.Sin((angFrequency * t) + Phase);

            return output;
        }
        public override float GetPointRelative(float t)
        {
            float angFrequency = 2 * (float)Math.PI * Frequency;

            return (float)Math.Sin((angFrequency * t) + Phase); ;
        }

        public override byte[] GetWaveformBytes(ulong samplerate, ulong length)
        {
            ulong totalsamples = samplerate * length * 1000;
            byte[] output = new byte[totalsamples * sizeof(float)];


            for (ulong i = 0; i < totalsamples; i++)
            {
                //Write the 4 bytes of this float sample
                byte[] currentsamplebytes = BitConverter.GetBytes(GetPointRelative(length / samplerate * i));

                //Add each byte to the array of output bytes
                for (ulong j = 0; j < sizeof(float); j++)
                {
                    output[i * sizeof(float) + j] = currentsamplebytes[j];
                }
            }

            return output;
        }
    }
}
