

namespace MALT200817.Checklist
{
    using MALT200817.Configuration;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    public class Check_06_XnetCanBusInterfaceType : ICheckItem
    {

        string _dut = "CanBusInterfaceType";
       

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " értékének ellenőrzése...";
            }
        }

        public string Result { get; set; }
        public ResultStatusType Status { get; set; }

        public void Process()
        {
            if (AppConfiguration.Instance.CanBusInterfaceType == "XNET")
            {
                Result = "A(z) " + _dut + " OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A(z) " + _dut + " csak XNET lehet! Error.";
                Status = ResultStatusType.Failed;
            }   

            Result += " Értéke: " + AppConfiguration.Instance.CanBusInterfaceType;
        }
    }
}
