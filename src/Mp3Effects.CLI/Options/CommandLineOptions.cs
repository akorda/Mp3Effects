using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace Mp3Effects.Options
{
    class CommandLineOptions : IEffectsOptions
    {
        [Value(0, Required = true, MetaName = "mp3", HelpText = "The mp3 file to apply the effects")]
        public string Mp3File { get; set; }

        [Value(1, MetaName = "semitones (half-steps)", Required = true, HelpText = "The semitones to change the pitch. Any positive or negative value, different that 0, is suitable")]
        public int Semitones { get; set; }

        //[Option(shortName:'v', longName: "verbose")]
        //public bool Verbose { get; set; }

        [Option(shortName: 'o', longName: "output", HelpText ="Output filename")]
        public string OutputFile { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {                
                yield return new Example("Lower the pitch of a song by 2 semitones. The output file will be 'song-2.mp3'", new CommandLineOptions { Mp3File = "song.mp3", Semitones = -2 });
                yield return new Example("Raise the pitch of a song by 3 semitones. The output file will be 'song+3.mp3'", new CommandLineOptions { Mp3File = "song.mp3", Semitones = 3 });
                yield return new Example("Raise the pitch of a song by 1 semitone. The output file will be 'modified.mp3'", new CommandLineOptions { Mp3File = "song.mp3", Semitones = 1, OutputFile = "modified.mp3" });
                //yield return new Example("Logging warnings", UnParserSettings.WithGroupSwitchesOnly(), new CommandLineOptions { InputFile = "file.bin", LogWarning = true });
                //yield return new Example("Logging errors", new[] { UnParserSettings.WithGroupSwitchesOnly(), UnParserSettings.WithUseEqualTokenOnly() }, new Options { InputFile = "file.bin", LogError = true });
            }
        }
    }
}
