using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    interface IAudio
    {
        FileStream fs { get; set; }
        BinaryWriter bw { get; set; }

        uint numsamples { get; set; }
        ushort numchannels { get; set; }
        ushort samplelength { get; set; }
        uint samplerate { get; set; }

        void CreateHeaders();
    }
}
