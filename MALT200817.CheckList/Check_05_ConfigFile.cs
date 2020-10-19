

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

    public class Check_05_ConfigFile : ICheckItem
    {

        string _dut = AppConstants.AppConfigurationFilePath;
       

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " meglétének ellenőrzése....";
            }
        }

        public string Result { get; set; }
        public ResultStatusType Status { get; set; }

        public void Process()
        {
            if (File.Exists(AppConstants.AppConfigurationFilePath))
            {
                Result = "A(z) " + _dut + " OK.";
                Status = ResultStatusType.Ok;
                AppConfiguration.Init();
            }
            else
            {
                Result = "A(z) " + _dut + " nem létezik. Error.";
                Status = ResultStatusType.Failed;
            }   
        }
    }
}
