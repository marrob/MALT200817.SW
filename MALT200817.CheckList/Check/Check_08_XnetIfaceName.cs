

namespace MALT200817.Checklist
{

    using System.Collections.Generic;
    using MALT200817.Configuration;
    using NiXnetDotNet;

    public class Check_08_XnetIfaceName : ICheckItem
    {

        string _dut = "XNET interfész név ";
       

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " helyességének elleőrzése";
            }
        }

        public string Result { get; set; }
        public ResultStatusType Status { get; set; }

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
            Result = string.Empty;
            Status = ResultStatusType.Unknown;
        }
    }
}
