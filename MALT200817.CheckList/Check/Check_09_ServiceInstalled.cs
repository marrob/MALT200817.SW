﻿
namespace MALT200817.Checklist
{

    using System.Collections.Generic;
    using MALT200817.Configuration;
    using System.ComponentModel;
    public class Check_10_ServiceInstalled : ICheckItem, INotifyPropertyChanged
    {

        string m_dut = "AltonTech MALT200817.Service(MaltService)";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Description 
        {
            get 
            {
                return "Az " + m_dut + " meglétének ellenőrzése.";
            }
        }

        string m_result;
        public string Result
        {
            get { return m_result; }
            set
            {
                if (m_result != value)
                {
                    m_result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }

        ResultStatusType m_status;
        public ResultStatusType Status
        {
            get { return m_status; }
            set
            {
                if (m_status != value)
                {
                    m_status = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
                }
            }
        }

        public void Process()
        {


            if (Tools.DoesServiceExist(AppConstants.WindowsServiceName)) 
            {
                Result = "A " + m_dut + " szolgáltatás telepítve van. OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A " + m_dut + " szolgáltatás nincs telepitve. Error.";
                Status = ResultStatusType.Failed;
            }

        }

        public void Dispose()
        {
     //       Result = string.Empty;
//Status = ResultStatusType.Unknown;
        }
    }
}
