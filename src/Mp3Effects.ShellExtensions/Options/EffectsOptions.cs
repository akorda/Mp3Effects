using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mp3Effects.Options
{
    class EffectsOptions : IEffectsOptions
    {
        public string Mp3File { get; set; }

        public int Semitones { get; set; }

        //public bool Verbose { get; set; }

        public string OutputFile { get; set; }
    }
}
