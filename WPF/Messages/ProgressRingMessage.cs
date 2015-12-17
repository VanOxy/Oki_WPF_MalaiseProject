using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Messages
{
    internal class ProgressRingMessage
    {
        public bool Active { get; private set; }

        public ProgressRingMessage(bool active)
        {
            Active = active;
        }
    }
}