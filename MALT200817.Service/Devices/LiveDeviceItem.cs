using System;
using System.Collections.Generic;
using System.Linq;

namespace MALT200817.Service.Devices
{ 
    public class LiveDeviceItem
    {
        public int FamilyCode { get; set; }
        public int Address { get; set; }
        public int OptionCode { get; set; }
        public string Version { get; set; }
        public List<byte[]> Ports { get; set; } /*Az elsö bájt legkisebb helyiértéke az első port*/
        public DeviceDescriptor Descriptor { get; private set; }
        public string PrimaryKey { get  {  return "@" + FamilyCode + "#" + Address; } }
        public string SerialNumber;

        public LiveDeviceItem(int familyCode, int address, int optionCode, int ver0, int ver1)
        {
            FamilyCode = familyCode;
            Address = address;
            OptionCode = optionCode;
            Version = "V" + ver1.ToString("X2") + ver0.ToString("X2");
            Descriptor = DevicesDesciptor.Instance.FirstOrDefault(n => n.FamilyCode == familyCode);
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

        public override bool Equals(object obj)
        {
            return obj is LiveDeviceItem item &&
                   FamilyCode == item.FamilyCode &&
                   Address == item.Address;
        }

        public override int GetHashCode()
        {
            int hashCode = 2012160261;
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(FamilyCode);
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
