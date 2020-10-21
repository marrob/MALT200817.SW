
namespace MALT200817.Checklist
{

    using System.Collections.Generic;
    using MALT200817.Configuration;
    using NiXnetDotNet;

    public class Check_10_ServiceRunning : ICheckItem
    {

        string _dut = "AltonTech MALT200817.Service(MaltService)";
       

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " futásának ellenőrzése.";
            }
        }

        public string Result { get; set; }
        public ResultStatusType Status { get; set; }

        public void Process()
        {
            var status = Tools.GetServiceStatus(AppConstants.WindowsServiceName);

            if ( status == "Running") 
            {
                Result = "A " + _dut + " szolgáltatás fut. OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A " + _dut + " szolgáltatás nem fut, állapota: Error." + status;
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
