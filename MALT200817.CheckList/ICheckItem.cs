using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Checklist
{
    public interface ICheckItem
    {
        string Description { get;  }
        string Result { get; set; }
        ResultStatusType Status { get; set; }
        void Process();
        void Dispose();
    }
}
