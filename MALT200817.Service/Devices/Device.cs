

using System;
using System.Collections.Generic;
using System.Linq;

namespace MALT200817.Service.Devices
{
    public class Device
    {
        public int CardType { get; set; }
        public int Address { get; set; }
        public int Options { get; set; }
        public string Version { get; set; }
        public List<byte[]> Ports { get; set; }
        public string CardName { get; set; }
        public DeviceDescriptor Descriptor { get; private set; }
        public string PrimaryKey { get  {  return "@" + CardType.ToString("X2") + "#" + Address.ToString("X2"); } }

        public Device(int cardType, int address, int options, int ver0, int ver1)
        {
            CardType = cardType;
            Address = address;
            Options = options;
            Version = "V" + ver1.ToString("X2") + ver0.ToString("X2");
            Descriptor = DevicesDesciptor.Instance.FirstOrDefault(n => n.CardType == cardType && n.Options == options);
            if (Descriptor != null)
            {
                Ports = new List<byte[]>();
                for (int blocks = 0; blocks < Descriptor.Blocks; blocks++)
                    Ports.Add(new byte[Descriptor.BytePerBlock]);
            }
        }


        public override string ToString()
        {
            return "@" + CardType.ToString("X2") + "#" + Address.ToString("X2") + "O" + Options.ToString("X2") + Version;
        }

        public void ResponsePortsStatus(int block, byte[] ports)
        {
            Array.Copy(ports, Ports[block], ports.Length);            
        }


    }
}
