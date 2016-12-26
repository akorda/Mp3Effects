using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mp3Effects.UI;

namespace MP3Effects.WinForms
{
    class ProgressBarProgressNotifier : IProgressNotifier
    {   
        public bool Enabled { get; set; } = true;
        ProgressBar ProgressBar { get; set; }
        public Label Label { get; set; }

        public ProgressBarProgressNotifier(ProgressBar progressBar, Label label)
        {
            this.ProgressBar = progressBar;
            this.Label = label;
        }

        public void Initialize(int maxTicks, string message)
        {
            this.ProgressBar.Minimum = 0;
            this.ProgressBar.Value = 0;
            this.ProgressBar.Maximum = maxTicks;
            this.Label.Text = message;
        }

        public void Tick(string message = null)
        {
            this.UpdateMessage(message);
            this.ProgressBar.Value++;
        }

        public void UpdateMessage(string message)
        {
            if (message == null) message = "";
            this.Label.Text = message;
        }
    }
}
