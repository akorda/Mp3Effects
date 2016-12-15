using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Effects.Options
{
    public interface IEffectsOptions
    {
        string Mp3File { get; }
        int Semitones { get; }
        string OutputFile { get; }
    }
}
