using System;
using System.Collections.Generic;
using System.Linq;

namespace Mp3Effects.UI
{
    public interface IProgressNotifier
    {
        void Initialize(int maxTicks, string message);
        void UpdateMessage(string message);
        void Tick(string message = null);
    }
}
