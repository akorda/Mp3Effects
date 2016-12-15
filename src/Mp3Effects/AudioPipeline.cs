using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mp3Effects.UI;
using Mp3Effects.Effects;
using NAudio.Wave;
using Mp3Effects.Options;

namespace Mp3Effects
{
    class AudioPipeline
    {
        public IProgressNotifier ProgressNotifier { get; set; }

        private List<Effect> Effects = new List<Effect>();
        private IEnumerable<Effect> EnabledEffects { get { return this.Effects.Where(e => e.Enabled); } }
        private PitchEffect PitchEffect { get; set; }

        public AudioPipeline(IProgressNotifier progressNotifier)
        {
            this.ProgressNotifier = progressNotifier;
            this.PitchEffect = new PitchEffect();
            this.Effects.Add(this.PitchEffect);
        }

        public void ApplyEffects(IEffectsOptions options, EffectSettings settings)
        {
            var mp3Path = options.Mp3File;
            this.PitchEffect.Semitones = settings.Pitch.Semitones;

            var tasksCount = 5;
            this.ProgressNotifier.Initialize(tasksCount, "Change the pitch of the mp3 file");

            this.ProgressNotifier.Tick("Read mp3 file...");
            var inMp3Bytes = File.ReadAllBytes(mp3Path);

            this.ProgressNotifier.Tick("Convert to wav...");
            var inWavBytes = AudioUtils.Mp3ToWav(inMp3Bytes);

            var waveSamples = AudioUtils.WavToWaveSamples(inWavBytes);
            var sampleRate = waveSamples.WaveFormat.SampleRate;
            var samples = waveSamples.Samples;
            this.InitializeEffects(sampleRate);

            this.ProgressNotifier.Tick("Apply effects...");
            this.ProcessSamples(samples, 0, samples.Length, waveSamples.WaveFormat);
                        
            var outWavBytes = AudioUtils.WaveSamplesToWav(waveSamples);

            this.ProgressNotifier.Tick("Convert to mp3...");
            var outMp3Bytes = AudioUtils.WavToMp3(outWavBytes);
            var outMp3Path = options.OutputFile;
            if (string.IsNullOrEmpty(outMp3Path)) outMp3Path = GetOutputMp3Path(mp3Path, settings.Pitch.Semitones);

            this.ProgressNotifier.Tick("Save mp3 file...");
            File.WriteAllBytes(outMp3Path, outMp3Bytes);

            this.ProgressNotifier.UpdateMessage("Finished!");
        }

        private static string GetOutputMp3Path(string mp3Path, int semitones)
        {
            var semitonesText = semitones.ToString();
            if (semitones > 0) semitonesText = "+" + semitonesText;

            var outputFilename = Path.GetFileNameWithoutExtension(mp3Path) + semitonesText + Path.GetExtension(mp3Path);
            var outputPath = Path.Combine(Path.GetDirectoryName(mp3Path), outputFilename);
            return outputPath;
        }

        private void InitializeEffects(int sampleRate)
        {
            foreach (var effect in this.EnabledEffects)
            {
                effect.SampleRate = sampleRate;
                effect.Initialize();
            }
        }        

        private void ProcessSamples(float[] buffer, int offset, int samplesCount, WaveFormat waveFormat)
        {            
            foreach (var effect in EnabledEffects)
            {
                effect.Block(samplesCount);
            }

            for (int sample = 0; sample < samplesCount; sample++)
            {
                var sampleLeft = buffer[offset];
                var sampleRight = sampleLeft;
                if (waveFormat.Channels == 2)
                {
                    sampleRight = buffer[offset + 1];
                    sample++;
                }

                // run these samples through the effect
                foreach (var effect in EnabledEffects)
                {
                    effect.ProcessSample(ref sampleLeft, ref sampleRight);
                }

                // put them back
                buffer[offset++] = sampleLeft;
                if (waveFormat.Channels == 2)
                {
                    buffer[offset++] = sampleRight;
                }
            }
        }
    }
}
