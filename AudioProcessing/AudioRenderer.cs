using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    class AudioRenderer
    {
        private float Amplitude = 1f;
        private float Frequency = 60f;
        private float Phase = 0f;
        private float Offset = 0f;
        private float Invert = 1;

        public AudioRenderer(float f = 60f, float a = 1f, float p = 0f, float o = 0f, float i = 1f)
        {
            Amplitude = a;
            Frequency = f;
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

    }
}
