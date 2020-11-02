using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MALT200817.Checklist
{
    public interface ICheckItem: INotifyPropertyChanged
    {
        string Description { get;  }
        string Result { get; set; }
        ResultStatusType Status { get; set; }
        void Process();
        void Dispose();
    }
}
