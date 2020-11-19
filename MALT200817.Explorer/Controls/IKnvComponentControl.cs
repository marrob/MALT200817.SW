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
        string Label { get; set; }
        int Port { get; set; }
        bool State { get; set; }
    }

    public interface IKnvInputComponentControl
    {
        string Label { get; set; }
        int Port { get; set; }
        bool State { get; set; }
    }
}
