using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    abstract class RendererBase
    {
        public float Frequency = 300f;
        public float Amplitude = 1f;
        public float Phase = 0f;
        public float Offset = 0f;
        public float Invert = 1;

        public RendererBase(float f, float a = 1f, float p = 0f, float o = 0f, float i = 1f)
        {
            Frequency = f;
            Amplitude = a;
            Phase = p;
            Offset = o;
            Invert = i;
        }

        public RendererBase()
        {
        }

    public abstract float GetPoint(float t);

        public abstract float GetPointRelative(float t);

        public abstract byte[] GetWaveformBytes(ulong samplerate, ulong length);
    }
}
