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
            var result = Parser.Default.ParseArguments<CommandLineOptions>(args).MapResult(options =>
            {
                return Run(options);
            }, 
            errors => -1);
            return result;            
        }

        private static int Run(IEffectsOptions options)
        {
            if (options.Semitones == 0)
            {
                Console.WriteLine("Changing the pitch by 0 semitones does not alter the original audio. Skipping.");
                return 0;
            }

            try
            {
                using (var progressBar = new ProgressBarProgressNotifier())
                {
                    var pipeline = new AudioPipeline(progressBar);
                    pipeline.ApplyEffects(options);
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