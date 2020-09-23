
namespace MALT200817.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using MALT200817.Library;

    public class LiveDeviceItem
    {
        public int FamilyCode { get; set; }
        public int Address { get; set; }
        public int OptionCode { get; set; }
        public string Version { get; set; }
        public List<byte[]> Ports { get; set; } /*Az elsö bájt legkisebb helyiértéke az első port*/
        public string PrimaryKey { get  {  return "@" + FamilyCode + "#" + Address; } }
        public string SerialNumber;
        public DeviceItem Device;
 

        public LiveDeviceItem(int familyCode, int address, int optionCode, int ver0, int ver1)
        {
            FamilyCode = familyCode;
            Address = address;
            OptionCode = optionCode;
            Version = "V" + ver1.ToString("X2") + ver0.ToString("X2");
            Device =  Devices.Instance.Search(familyCode, optionCode);
          
            if (Device != null)
            {
                Ports = new List<byte[]>();
                for (int blocks = 0; blocks < Device.BlockSize; blocks++)
                    Ports.Add(new byte[Device.BlockSize]);
            }
            else
            {
                AppLog.Instance.WriteLine("This device not suppoerted" + familyCode.ToString());
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

        public void SetSerialNumber(byte[] serialNumByteArray)
        {
            SerialNumber = BitConverter.ToInt32(serialNumByteArray, 0).ToString();
        }
    }
}
