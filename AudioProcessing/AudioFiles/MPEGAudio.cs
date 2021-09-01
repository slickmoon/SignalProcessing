using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    class MPEGAudio : IAudio
    {
        public FileStream fs { get; set; }
        public BinaryWriter bw { get; set; }

        public void CreateHeaders()
        {

        }
    }
}
