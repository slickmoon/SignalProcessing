using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    class MPEGAudio : IAudio
    {
        public FileStream fs { get; set; }
        public BinaryWriter bw { get; set; }

        public uint numsamples { get; set; }
        public ushort numchannels { get; set; }
        public ushort samplelength { get; set; }
        public uint samplerate { get; set; }

        public MPEGAudio(string file)
        {
            fs = new FileStream(file, FileMode.Create);
            bw = new BinaryWriter(fs);

            numsamples = 8000;//44100;
            numchannels = 1;
            samplelength = 1;
            samplerate = 4000;
        }

        public void CreateHeaders()
        {
            bw.Write(Encoding.ASCII.GetBytes("RIFF"));
            bw.Write(36 + numsamples * numchannels * samplelength);
            bw.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
            bw.Write(16);
            bw.Write((ushort)1);
            bw.Write(numchannels);
            bw.Write(samplerate);
            bw.Write(samplerate * samplelength * numchannels);
            bw.Write(samplelength * numchannels);
            bw.Write((ushort)(8 * samplelength));
            bw.Write("data");
            bw.Write(numsamples * samplelength);
        }
    }
}
