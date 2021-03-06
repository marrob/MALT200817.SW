﻿
namespace MALT200817.Checklist
{

    using MALT200817.Configuration;
    using System.ComponentModel;

    public class Check_11_ServiceRunning : ICheckItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string m_dut = "AltonTech MALT200817.Service(MaltService)";
       

        public string Description 
        {
            get 
            {
                return "Az " + m_dut + " futásának ellenőrzése.";
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
            var status = Tools.GetServiceStatus(AppConstants.WindowsServiceName);

            if ( status == "Running") 
            {
                Result = "A " + m_dut + " szolgáltatás fut. OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A " + m_dut + " szolgáltatás nem fut, állapota: Error." + status;
                Status = ResultStatusType.Failed;
            }
        }

        public void Dispose()
        {
       //     Result = string.Empty;
//Status = ResultStatusType.Unknown;
        }
    }
}
