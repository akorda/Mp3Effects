using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mp3Effects.UI;

namespace Mp3Effects
{
    class EffectSettings
    {
        public PitchSettings Pitch { get; set; }
    }

    class PitchSettings
    {
        public int Semitones { get; set; }
    }
}
