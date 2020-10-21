
namespace MALT200817.Checklist
{

    using System.Collections.Generic;
    using MALT200817.Configuration;
    using NiXnetDotNet;

    public class Check_09_ServiceInstalled : ICheckItem
    {

        string _dut = "AltonTech MALT200817.Service(MaltService)";
       

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " meglétének ellenőrzése.";
            }
        }

        public string Result { get; set; }
        public ResultStatusType Status { get; set; }

        public void Process()
        {


            if (Tools.DoesServiceExist(AppConstants.WindowsServiceName)) 
            {
                Result = "A " + _dut + " szolgáltatás telepítve van. OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A " + _dut + " szolgáltatás nincs telepitve. Error.";
                Status = ResultStatusType.Failed;
            }


        }

        public void Dispose()
        {
            Result = string.Empty;
            Status = ResultStatusType.Unknown;
        }
    }
}
