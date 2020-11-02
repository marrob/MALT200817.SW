

namespace MALT200817.Checklist
{

    using System.Collections.Generic;
    using NiXnetDotNet;
    using System.ComponentModel;

    public class Check_08_XnetDevice : ICheckItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string m_dut = "XNET eszköz ";
       

        public string Description 
        {
            get 
            {
                return "Az " + m_dut + " meglétének elleőrzése";
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
            if (devices.Count != 0) 
            {
                Result = "A rednszer tartalmaz " +  devices.Count + "db XNET eszközt. OK. " + " Az első típusa: "  + devices[0];
                Status = ResultStatusType.Ok;
            }
            else
            {
                Result = "A rendszer nem tartalmaz XNET-et támogató eszközt. Error.";
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
