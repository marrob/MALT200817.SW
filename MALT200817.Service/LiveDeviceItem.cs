
namespace MALT200817.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using MALT200817.Library;

    public class LiveDeviceItem
    {
        public int FamilyCode { get; private set; }
        public int Address { get; private set; }
        public int OptionCode { get; private set; } /*Az option kódotól független a tipus.*/
        public string Version { get; private set; }
        public List<byte[]> Ports { get; private set; } /*Az elsö bájt legkisebb helyiértéke az első port*/
        public int[] Counters {get; private set; } /*Az indexek a portok, az értékek a számlálók értékei */
        public string FirstName { get; private set; }
        public string SerialNumber { get; private set; }
        public DeviceItem Device;
 

        public LiveDeviceItem(int familyCode, int address, int optionCode, int ver0, int ver1)
        {
            FamilyCode = familyCode;
            Address = address;
            OptionCode = optionCode;
            Version = "V" + ver1.ToString("X2") + ver0.ToString("X2");

            Device =  Devices.Library.Search(familyCode, optionCode);
            if (Device != null)
            {
                Ports = new List<byte[]>();
                for (int blocks = 0; blocks < Device.Blocks; blocks++)
                    Ports.Add(new byte[Device.BlockSize]);
                Counters = new int[Devices.Library.GetRealyCount(familyCode, optionCode)];
                FirstName = Device.FirstName;
            }
            else
            {
                Device = Devices.Library.Search(familyCode);
                if (Device != null)
                {
                    Ports = new List<byte[]>();
                    for (int blocks = 0; blocks < Device.Blocks; blocks++)
                        Ports.Add(new byte[Device.BlockSize]);
                    Counters = new int[Devices.Library.GetRealyCount(familyCode)];
                    AppLog.Instance.WriteLine("This device not supported by option " +
                    "OptionCode:" + optionCode.ToString("X2"));
                    FirstName = "This device not supported by option";
                }
                else
                {
                    AppLog.Instance.WriteLine("This device not suppoerted: " +
                    "FamilyCode:" + familyCode.ToString("X2") + 
                    "OptionCode:" + optionCode.ToString("X2"));
                }
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
