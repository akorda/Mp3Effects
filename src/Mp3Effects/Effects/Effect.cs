using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Mp3Effects.Effects
{
    public abstract class Effect
    {
        public bool Enabled { get; set; } = true;
        protected bool ParametersChanged { get; set; } = true;

        protected float Param1;
        protected float Param2;
        protected float Param3;
        protected float Param4;
        protected float Param5;
        protected float Param6;
        protected float Param7;
        protected float Param8;

        public float SampleRate { get; set; }

        #region Math Functions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float min(float a, float b) { return Math.Min(a, b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float max(float a, float b) { return Math.Max(a, b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float abs(float a) { return Math.Abs(a); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float exp(float a) { return (float)Math.Exp(a); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float sqrt(float a) { return (float)Math.Sqrt(a); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float sin(float a) { return (float)Math.Sin(a); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float tan(float a) { return (float)Math.Tan(a); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float cos(float a) { return (float)Math.Cos(a); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float pow(float a, float b) { return (float)Math.Pow(a, b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float sign(float a) { return Math.Sign(a); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected static float log(float a) { return (float)Math.Log(a); }
        protected static float PI { get { return (float)Math.PI; } }
        protected static void convolve_c(float[] buffer1, int offset1, float[] buffer2, int offset2, int count)
        {
            for (int i = 0; i < count * 2; i += 2)
            {
                float r = buffer1[offset1 + i];
                float im = buffer1[offset1 + i + 1];
                float cr = buffer2[offset2 + i];
                float ci = buffer2[offset2 + i + 1];
                buffer1[offset1 + i] = r * cr - im * ci;
                buffer1[offset1 + i + 1] = r * ci + im * cr;
            }
        }
        #endregion

        public void ProcessSample(ref float left, ref float right)
        {
            if (this.ParametersChanged)
            {
                this.ApplyParameters();
                this.ParametersChanged = false;
            }
            this.ProcessSampleInt(ref left, ref right);
        }

        public virtual void Initialize()
        {
        }

        /// <summary>
        /// called before each block is processed
        /// </summary>
        /// <param name="blockSamplesCount">number of samples in this block</param>
        public virtual void Block(int blockSamplesCount)
        {
        }

        protected abstract void ApplyParameters();

        public abstract string Name { get; }

        /// <summary>
        /// called for each sample
        /// </summary>        
        protected abstract void ProcessSampleInt(ref float spl0, ref float spl1);
    }
}
