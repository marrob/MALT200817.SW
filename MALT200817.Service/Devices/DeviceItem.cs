using System;
using System.Collections.Generic;
using System.Linq;

namespace MALT200817.Service.Devices
{
    class Valami
    { 
    
    }


    public class DeviceItem
    {
        public int CardType { get; set; }
        public int Address { get; set; }
        public int Options { get; set; }
        public string Version { get; set; }
        public List<byte[]> Ports { get; set; } /*Az elsö bájt legkisebb helyiértéke az első port*/
        public DeviceDescriptor Descriptor { get; private set; }
        public string PrimaryKey { get  {  return "@" + CardType + "#" + Address; } }
        public string SerialNumber;

        public DeviceItem(int cardType, int address, int options, int ver0, int ver1)
        {
            CardType = cardType;
            Address = address;
            Options = options;
            Version = "V" + ver1.ToString("X2") + ver0.ToString("X2");
            Descriptor = DevicesDesciptor.Instance.FirstOrDefault(n => n.CardType == cardType);
            if (Descriptor != null)
            {
                Ports = new List<byte[]>();
                for (int blocks = 0; blocks < Descriptor.Blocks; blocks++)
                    Ports.Add(new byte[Descriptor.BytePerBlock]);
            }
            else
            {
                Descriptor = DevicesDesciptor.Instance[0];
            }
        }


        public override string ToString()
        {
            //CARD_TYPE:ADDRESS:OPTIONS:VERSION:SERIALNUMBER:CARD_NAME
            return "@" + CardType.ToString("X2") + ":" + Address.ToString("X2") + ":" + Options.ToString("X2") + ":" + Version + ":" + SerialNumber + ":" + Descriptor.CardName;
        }

        public override bool Equals(object obj)
        {
            return obj is DeviceItem item &&
                   CardType == item.CardType &&
                   Address == item.Address;
        }

        public override int GetHashCode()
        {
            int hashCode = 2012160261;
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(CardType);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Address);
            return hashCode;
        }

        public void SetPortsStatus(int block, byte[] ports)
        {
            if (Ports != null)
                Array.Copy(ports, Ports[block], ports.Length);            
        }

        public void SetSerialNumber()
        {
        }
    }
}
