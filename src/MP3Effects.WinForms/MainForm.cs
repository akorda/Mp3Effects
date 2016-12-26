using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mp3Effects;
using Mp3Effects.Options;

namespace MP3Effects.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ApplyEffectsButton_Click(object sender, EventArgs e)
        {
            var options = new EffectsOptions
            {
                Mp3File = this.InputPathTextBox.Text,
                OutputFile = this.OutputPathTextBox.Text,
                Semitones = this.SemitonesTrackBar.Value
            };
            this.ApplyEffects(options);
        }

        private void BrowseOutputFileButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "MP3 files|*.mp3|All Files|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.OutputPathTextBox.Text = dialog.FileName;
                }
            }
        }

        private void BrowseInputFileButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "MP3 files|*.mp3|All Files|*.*";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.InputPathTextBox.Text = dialog.FileName;
                }
            }
        }

        private int ApplyEffects(IEffectsOptions options)
        {
            if (options.Semitones == 0)
            {
                MessageBox.Show("Changing the pitch by 0 semitones does not alter the original audio. Skipping.");
                return 0;
            }

            try
            {
                var progressBar = new ProgressBarProgressNotifier(this.ProgressBar, this.ProgressLabel);
                var pipeline = new AudioPipeline(progressBar);
                pipeline.ApplyEffects(options);

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private void SemitonesTrackBar_Scroll(object sender, EventArgs e)
        {
            var value = this.SemitonesTrackBar.Value;
            if (value != 0)
            {
                var sign = value > 0 ? "+" : "";
                this.SemitonesLabel.Text = $"Semitones {sign}{value}";
                this.ApplyEffectsButton.Enabled = true;
            }
            else
            {
                this.SemitonesLabel.Text = "Semitones";
                this.ApplyEffectsButton.Enabled = false;
            }
        }
    }
}
