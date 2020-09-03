using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Explorer.Client
{
    public class DeviceItem
    {   
        public string CardName { get; private set; }
        public string CardType { get; private set; }
        public string Address { get; private set; }
        public string Version { get; private set; }
        public string SerialNumber { get; private set; }

        public DeviceItem(string name, string cardType, string address, string version, string serialNumber)
        {
            CardName = name;
            CardType = cardType;
            Address = address;
            Version = version;
            SerialNumber = serialNumber;
        }


      
    }
}
