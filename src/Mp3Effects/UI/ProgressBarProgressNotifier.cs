using System;
using System.Collections.Generic;
using System.Linq;
using ShellProgressBar;

namespace Mp3Effects.UI
{
    public class ProgressBarProgressNotifier : IProgressNotifier, IDisposable
    {
        ConsoleColor ForegroundColor { get; set; }

        ProgressBar _ProgressBar;
        ProgressBar ProgressBar
        {
            get
            {
                if (_ProgressBar == null) _ProgressBar = new ProgressBar(100, "", ConsoleColor.Blue);
                return _ProgressBar;
            }
        }

        public ProgressBarProgressNotifier(ConsoleColor foregroundColor = ConsoleColor.White)
        {
            this.ForegroundColor = ConsoleColor.White;
        }

        public void Initialize(int maxTicks, string message)
        {
            _ProgressBar = new ProgressBar(maxTicks, message, this.ForegroundColor);
        }

        public void UpdateMessage(string message)
        {            
            this.ProgressBar.UpdateMessage(message);
        }

        public void Tick(string message = null)
        {
            this.ProgressBar.Tick(message);
        }

        public void Dispose()
        {
            this.ProgressBar.Dispose();
        }
    }
}
