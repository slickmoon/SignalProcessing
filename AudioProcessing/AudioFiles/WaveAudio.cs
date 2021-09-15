using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    class WaveAudio : AudioFile
    { 
        const byte HeaderSize = 8;

        /// <summary>
        /// WAVE Stream
        /// </summary>
        /// <param name="stream"></param>
        public WaveAudio(Stream stream) : base(stream)
        {
            WriteHeader();
        }

        public void WriteHeader()
        {
            UInt16 frequency = 650;
            int msDuration = 1000;
            UInt16 volume = 16383;

            int formatChunkSize = 16;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * msDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + HeaderSize + formatChunkSize + HeaderSize + dataChunkSize;

            Bin.Write(0x46464952); //RIFF
            Bin.Write(fileSize);
            Bin.Write(0x45564157); //WAVE
            Bin.Write(0x20746D66); //fmt
            Bin.Write(formatChunkSize);
            Bin.Write(formatType);
            Bin.Write(tracks);
            Bin.Write(samplesPerSecond);
            Bin.Write(bytesPerSecond);
            Bin.Write(frameSize);
            Bin.Write(bitsPerSample);
            Bin.Write(0x61746164); //data
            Bin.Write(dataChunkSize);

            //not supposed to be here
            double theta = frequency * Math.Constants.Pi2 / (double)samplesPerSecond;
            // 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
            // we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
            double amp = volume >> 2; // so we simply set amp = volume / 2
            for (int step = 0; step < samples; step++)
            {
                Bin.Write((short)(amp * System.Math.Sin(theta * (double)step)));
            }
        }
    }
}
