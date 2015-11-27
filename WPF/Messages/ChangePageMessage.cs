using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Message
{
    internal class ChangePageMessage
    {
        public string PageName { get; private set; }

        public ChangePageMessage(string pageName)
        {
            PageName = pageName;
        }
    }
}