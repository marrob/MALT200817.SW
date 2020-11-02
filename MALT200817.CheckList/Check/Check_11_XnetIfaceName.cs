

namespace MALT200817.Checklist
{
    using System.Collections.Generic;
    using MALT200817.Configuration;
    using NiXnetDotNet;
    using System.ComponentModel;

    public class Check_09_XnetIfaceName : ICheckItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string m_dut = "XNET interfész név ";
       

        public string Description 
        {
            get 
            {
                return "Az " + m_dut + " helyességének elleőrzése";
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

            var m_system = new NiXnetSystem();
            List<string> devices = new List<string>();
            List<string> names = new List<string>();

            foreach (NiXnetDevice device in m_system.ListDevices())
            {
                devices.Add(device.ToString()); 
                foreach (NiXnetInterface iface in device.Interfaces)
                {
                    names.Add(iface.Name);
                }
            }

            if (names.Contains(AppConfiguration.Instance.CanBusInterfaceName)) 
            {
                Result = "A rednszer tartalmaz egy db " + AppConfiguration.Instance.CanBusInterfaceName + " nevű interfészt. OK.";
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A rednszer tartalmaz nem tartalmaz " + AppConfiguration.Instance.CanBusInterfaceName + " nevű interfészt. Error.";
                Status = ResultStatusType.Failed;
            }


        }

        public void Dispose()
        {
//Result = string.Empty;
//Status = ResultStatusType.Unknown;
        }
    }
}
