using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Lame;
using NAudio.Utils;
using NAudio.Wave;

namespace Akorda.Mp3Effects
{
    public static class AudioUtils
    {
        public static WaveSamples WavToWaveSamples(byte[] wavBytes)
        {
            var waveSamples = new WaveSamples();
            using (var inWavStream = new MemoryStream(wavBytes))
            using (var wavReader = new WaveFileReader(inWavStream))
            {
                waveSamples.WaveFormat = wavReader.WaveFormat;
                var sampleProvider = wavReader.ToSampleProvider();
                var samples = new float[inWavStream.Length];
                var samplesCount = sampleProvider.Read(samples, 0, samples.Length);
                Array.Resize(ref samples, samplesCount);
                waveSamples.Samples = samples;
            }
            return waveSamples;
        }

        public static byte[] WaveSamplesToWav(WaveSamples samples)
        {
            using (var wavStream = new MemoryStream())
            using (var wavWriter = new WaveFileWriter(wavStream, samples.WaveFormat))
            {
                wavWriter.WriteSamples(samples.Samples, 0, samples.Samples.Length);
                wavWriter.Flush();
                return wavStream.ToArray();
            }
        }

        public static byte[] WavToMp3(byte[] wavBytes, int bitRate = 128)
        {
            using (var mp3Stream = new MemoryStream())
            using (var wavStream = new MemoryStream(wavBytes))
            using (var reader = new WaveFileReader(wavStream))
            using (var writer = new LameMP3FileWriter(mp3Stream, reader.WaveFormat, bitRate))
            {
                reader.CopyTo(writer);
                return mp3Stream.ToArray();
            }
        }

        public static byte[] Mp3ToWav(byte[] mp3Bytes)
        {
            using (var mp3Stream = new MemoryStream(mp3Bytes))
            using (var reader = new Mp3FileReader(mp3Stream))
            {
                var outFormat = new WaveFormat(reader.WaveFormat.SampleRate, reader.WaveFormat.Channels);
                using (var resampler = new MediaFoundationResampler(reader, outFormat))
                {
                    using (var wavStream = new MemoryStream())
                    {
                        WriteWavFileToStream(wavStream, resampler);
                        return wavStream.ToArray();
                    }
                }
            }
        }

        //from https://github.com/naudio/NAudio/blob/master/NAudio/Wave/WaveOutputs/WaveFileWriter.cs
        private static void WriteWavFileToStream(Stream stream, IWaveProvider sourceProvider)
        {
            using (var writer = new WaveFileWriter(new IgnoreDisposeStream(stream), sourceProvider.WaveFormat))
            {
                var buffer = new byte[sourceProvider.WaveFormat.AverageBytesPerSecond * 4];
                while (true)
                {
                    var bytesRead = sourceProvider.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // end of source provider
                        stream.Flush();
                        break;
                    }

                    writer.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
