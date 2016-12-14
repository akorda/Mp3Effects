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

        [Value(1, MetaName = "semitones", Required = true, HelpText = "The semitones to change the pitch. Any positive or negative value, different that 0, is suitable")]
        public int Semitones { get; set; }

        //[Option(shortName:'v', longName: "verbose")]
        //public bool Verbose { get; set; }
        
        //[Usage(ApplicationAlias = "aaa")]
        public static IEnumerable<Example> Examples
        {
            get
            {                
                yield return new Example("Simple usage", new CommandLineOptions { Mp3File = "audio.mp3", Semitones = -2 });
                //yield return new Example("Logging warnings", UnParserSettings.WithGroupSwitchesOnly(), new CommandLineOptions { InputFile = "file.bin", LogWarning = true });
                //yield return new Example("Logging errors", new[] { UnParserSettings.WithGroupSwitchesOnly(), UnParserSettings.WithUseEqualTokenOnly() }, new Options { InputFile = "file.bin", LogError = true });
            }
        }
    }
}
