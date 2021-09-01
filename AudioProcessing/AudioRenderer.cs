using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    class AudioRenderer
    {
        private float Frequency = 300f;
        private float Amplitude = 1f;
        private float Phase = 0f;
        private float Offset = 0f;
        private float Invert = 1;

        //for overriding properties of the waveform
        public AudioRenderer(float f, float a = 1f, float p = 0f, float o = 0f, float i = 1f)
        {
            Frequency = f;
            Amplitude = a;
            Phase = p;
            Offset = o;
            Invert = i;
        }

        public AudioRenderer()
        { }
        
        public float GetPoint(float t)
        {
            float output = 0f;
            float angFrequency = 2 * (float)Math.PI * Frequency;
            output = Amplitude * (float)Math.Sin((angFrequency * t) + Phase);

            return output;
        }
        public float GetPointRelative(float t)
        {
            float angFrequency = 2 * (float)Math.PI * Frequency;

            return (float)Math.Sin((angFrequency * t) + Phase); ;
        }

        // TODO: change lengthsecs to lengthmillisecs
        public byte[] GetWaveformBytes (ulong samplerate, ulong lengthsecs = 1)
        {
            ulong totalsamples = (samplerate * lengthsecs)+1;
            byte[] output = new byte[totalsamples*sizeof(float)];


            for(ulong i = 0; i < totalsamples; i++)
            {
                float currentsamplepos = ((float)lengthsecs / (float)samplerate) * (float)i;
                float f = GetPointRelative(currentsamplepos);
                //Write the 4 bytes of this float sample
                byte[] currentsamplebytes = BitConverter.GetBytes(f);
                //currentsamplebytes = BitConverter.GetBytes(0.5f);
                ulong bytelength = (ulong)currentsamplebytes.Length;

                //Add each byte to the array of output bytes
                for (ulong j = 0; j < (ulong)currentsamplebytes.Length; j++)
                {
                    output[(i*sizeof(float)) + j] = currentsamplebytes[j];
                }
            }

            return output;
        }

    }
}
