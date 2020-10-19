using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Checklist
{
    public class Check_00_NetFramework : ICheckItem
    {

        string _dut = "Microsoft .NET Framework 4.7.2 Targeting Pack";

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " meglétének ellenőrzése...";
            }
        }

        public string Result { get; set; }

        public ResultStatusType Status { get; set; }


        public void Process()
        {
            if (Tools.IsApplicationInstalled(_dut))
            {
                Result = "A(z) " + _dut + " OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A(z) " + _dut + " Nincs telepitve vagy nem megfelelő verzió. Error.";
                Status = ResultStatusType.Failed;
            }   
        }
    }
}
