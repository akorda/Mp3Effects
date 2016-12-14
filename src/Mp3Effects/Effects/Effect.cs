using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akorda.Mp3Effects.Effects
{
    public abstract class Effect
    {
        public bool Enabled { get; set; } = true;

        protected float slider1;
        protected float slider2;
        protected float slider3;
        protected float slider4;
        protected float slider5;
        protected float slider6;
        protected float slider7;
        protected float slider8;

        public float SampleRate { get; set; }

        protected float min(float a, float b) { return Math.Min(a, b); }
        protected float max(float a, float b) { return Math.Max(a, b); }
        protected float abs(float a) { return Math.Abs(a); }
        protected float exp(float a) { return (float)Math.Exp(a); }
        protected float sqrt(float a) { return (float)Math.Sqrt(a); }
        protected float sin(float a) { return (float)Math.Sin(a); }
        protected float tan(float a) { return (float)Math.Tan(a); }
        protected float cos(float a) { return (float)Math.Cos(a); }
        protected float pow(float a, float b) { return (float)Math.Pow(a, b); }
        protected float sign(float a) { return Math.Sign(a); }
        protected float log(float a) { return (float)Math.Log(a); }
        protected float PI { get { return (float)Math.PI; } }

        protected void convolve_c(float[] buffer1, int offset1, float[] buffer2, int offset2, int count)
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


        private bool sliderChanged = true;
        public void OnSample(ref float left, ref float right)
        {
            if (sliderChanged)
            {
                Slider();
                sliderChanged = false;
            }
            Sample(ref left, ref right);
        }

        public virtual void Init()
        {

        }

        /// <summary>
        /// called before each block is processed
        /// </summary>
        /// <param name="samplesblock">number of samples in this block</param>
        public virtual void Block(int samplesblock)
        {
        }

        protected abstract void Slider();

        /// <summary>
        /// called for each sample
        /// </summary>        
        protected abstract void Sample(ref float spl0, ref float spl1);
    }
}
