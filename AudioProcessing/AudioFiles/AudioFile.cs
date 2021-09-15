using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessing
{
    public class AudioFile
    {
        public BinaryWriter Bin;
        public Stream Stream;

        public AudioFile(Stream stream)
        {
            Stream = stream;
            Bin = new BinaryWriter(stream);
        }
    }
}
