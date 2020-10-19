using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Checklist
{
    public class Check_02_LabView : ICheckItem
    {

        string _dut = "NI LabVIEW 2018 (32-bit)";

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
                Result = "A(z) " + _dut + " nincs telepitve vagy nem  megfelelő verzió. Rendben.";
                Status = ResultStatusType.Failed;
            }   
        }
    }
}
