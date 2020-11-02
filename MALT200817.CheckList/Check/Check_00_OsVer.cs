using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MALT200817.Checklist
{
    public class Check_00_OsVer : ICheckItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string[] AcceptVesions =
        {
            "10.0.19041",
        };

        
        public string Description 
        {
            get 
            {
                return "Az operációs rendszer verziójának ellenörzése.";
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
            var ver = Tools.GetOsVer();
            if (AcceptVesions.Contains(ver))
            {
                Status = ResultStatusType.Ok;
                Result = "Az OS OK. aktuális verzió:" + ver;
            }
            else
            {
                Status = ResultStatusType.Warning;
                Result = "Az OS nem támogatott, aktuális verzió:" + Tools.GetOsVer();
            }

        }
        public void Dispose()
        {
          //  Result = string.Empty ;
         //   Status = ResultStatusType.Unknown;
        }
    }
}
