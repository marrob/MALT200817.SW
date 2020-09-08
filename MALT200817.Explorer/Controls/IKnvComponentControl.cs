using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Explorer.Controls
{
    public interface IKnvOutputComponentControl 
    {
        event EventHandler ComponentClick;
        int Port { get; set; }
        bool State { get; set; }
    }
}
