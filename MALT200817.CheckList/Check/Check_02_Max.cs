using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MALT200817.Checklist
{
    public class Check_02_Max : ICheckItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string[] AcceptVesions =
        {
            "19.00.49152",
            "20.0.0",
        };

        string m_dut = "NI Measurement & Automation Explorer";

        public string Description 
        {
            get 
            {
                return "A(z) " + m_dut + " meglétének és verziójának ellenőrzése...";
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
            var ver = Tools.IsApplicationInstalled(m_dut);
            if (ver == null)
            {
                Status = ResultStatusType.Failed;
                Result = "A(z) " + m_dut + " nincs telepítve.";

            }
            else if (AcceptVesions.Contains(ver))
            {
                Status = ResultStatusType.Ok;
                Result = "A(z) " + m_dut + " OK. aktuális verzió:" + ver;
            }
            else
            {
                Status = ResultStatusType.Warning;
                Result = "A(z) " + m_dut + " nem támogatott verzió, aktuális verzió:" + ver;
            }
        }

        public void Dispose()
        {
        //    Result = string.Empty;
        //    Status = ResultStatusType.Unknown;
        }
    }
}
