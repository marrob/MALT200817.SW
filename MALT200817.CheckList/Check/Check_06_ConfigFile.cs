

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

    public class Check_06_ConfigFile : ICheckItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _dut = AppConstants.AppConfigurationFilePath;
       

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " meglétének ellenőrzése...";
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

        public void Dispose()
        {
        //    Result = string.Empty;
//Status = ResultStatusType.Unknown;
        }
    }
}
