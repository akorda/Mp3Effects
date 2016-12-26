using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mp3Effects.Options;

namespace MP3Effects.WinForms
{
    class EffectsOptions : IEffectsOptions
    {
        public string Mp3File { get; set; }
        public int Semitones { get; set; }
        public string OutputFile { get; set; }
    }
}
