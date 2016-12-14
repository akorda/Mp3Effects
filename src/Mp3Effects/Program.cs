using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Akorda.Mp3Effects.Effects;
using NAudio.Wave;

namespace Akorda.Mp3Effects
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0 || args.Length != 2)
            {
                ShowUsage();
                return -1;
            }

            var inputMp3Path = args[0];
            int semitones ;
            if (!int.TryParse(args[1], out semitones))
            {
                ShowUsage();
                return -1;
            }

            if (semitones == 0)
            {
                Console.WriteLine("Changing the pitch by 0 semitones does not alter the original audio. Skipping.");
                return 0;
            }

            try
            {
                new AudioPipeline().ApplyEffects(inputMp3Path, semitones);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------- akorda -----------------------");
            Console.WriteLine("-  Change the pitch of an mp3 be several semitones   -");
            Console.WriteLine("-  Usage:                                            -");
            Console.WriteLine("-  mp3effects mp3_file semitones                     -");
            Console.WriteLine("-  , semitones <> 0                                  -");
            Console.WriteLine("----------------------- akorda -----------------------");
        }
    }
}
