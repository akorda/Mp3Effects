using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace Mp3Effects.Options
{
    class CommandLineOptions
    {
        [Value(0, Required = true, MetaName = "mp3", HelpText = "The mp3 file to apply the effects")]
        public string Mp3File { get; set; }

        [Value(1, MetaName = "semitones", Required = true, HelpText = "The semitones to change the pitch with value <> 0")]
        public int Semitones { get; set; }
    }
}
