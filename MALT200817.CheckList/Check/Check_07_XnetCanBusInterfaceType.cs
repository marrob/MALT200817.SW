

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
    using System.ComponentModel;

    public class Check_07_XnetCanBusInterfaceType : ICheckItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string[] AcceptTypes =
        {
            "XNET",
        };

        string m_dut = "CanBusInterfaceType";
       

        public string Description 
        {
            get 
            {
                return "Az " + m_dut + " értékének ellenőrzése...";
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
            if (AcceptTypes.Contains(AppConfiguration.Instance.CanBusInterfaceType))
            {
                Result = "A(z) " + m_dut + " OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A(z) " + m_dut + " csak XNET lehet! Error.";
                Status = ResultStatusType.Failed;
            }   

            Result += " Értéke: " + AppConfiguration.Instance.CanBusInterfaceType;
        }

        public void Dispose()
        {
          //  Result = string.Empty;
//Status = ResultStatusType.Unknown;
        }
    }
}
