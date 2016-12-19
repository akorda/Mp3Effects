using System;
using System.Collections.Generic;
using System.Linq;

namespace Mp3Effects.UI
{
    public class EmptyProgressNotifier : IProgressNotifier
    {
        public bool Enabled { get; set; } = true;
        
        public void Initialize(int maxTicks, string message)
        {        
        }

        public void UpdateMessage(string message)
        {                    
        }

        public void Tick(string message = null)
        {            
        }
    }
}
