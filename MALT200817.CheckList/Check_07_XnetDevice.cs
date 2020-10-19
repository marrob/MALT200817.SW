

namespace MALT200817.Checklist
{

    using System.Collections.Generic;
    using NiXnetDotNet;

    public class Check_07_XnetDevice : ICheckItem
    {

        string _dut = "XNET eszköz ";
       

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " meglétének elleőrzése";
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
    }
}
