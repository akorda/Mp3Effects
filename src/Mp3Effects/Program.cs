using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using Mp3Effects.Options;
using Mp3Effects.UI;

namespace Mp3Effects
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputMp3Path = "";
            var settings = new EffectSettings();
            var result = Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(options =>
            {
                inputMp3Path = options.Mp3File;
                settings.Pitch = new PitchSettings { Semitones = options.Semitones };
            }).MapResult(options =>
            {
                return Run(inputMp3Path, settings);
            }, 
            errors => -1);
            return result;            
        }

        private static int Run(string inputMp3Path, EffectSettings settings)
        {
            if (settings.Pitch.Semitones == 0)
            {
                Console.WriteLine("Changing the pitch by 0 semitones does not alter the original audio. Skipping.");
                return 0;
            }

            try
            {
                using (var progressBar = new ProgressBarProgressNotifier())
                {
                    var pipeline = new AudioPipeline(progressBar);
                    pipeline.ApplyEffects(inputMp3Path, settings);
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}