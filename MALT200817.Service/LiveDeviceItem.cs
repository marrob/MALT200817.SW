
namespace MALT200817.Service
{
    using System;
    using System.Collections.Generic;
    using Common;
    using MALT200817.Library;

    public class LiveDeviceItem
    {
        public int FamilyCode { get; private set; } /*Eszköz család azonosító*/
        public int Address { get; private set; }
        public bool IsDeviceOk { get; private set; }
        public int OptionCode { get; private set; } /*Az option kódotól független a tipus.*/
        public string Version { get; private set; }
        public List<byte[]> Ports { get; private set; } /*Az elsö bájt legkisebb helyiértéke az első port*/
        public int[] Counters {get; private set; } /*Az indexek a portok, az értékek a számlálók értékei */
        public string FirstName { get; private set; }
        public string SerialNumber { get; private set; }
        public int BlockSize{
            get
            {
                if (_device != null)
                    return _device.BlockSize;
                else
                    return 0;
            }
        }
        public string FamilyName {
            get {
                if (_device != null)
                    return _device.FamilyName;
                else
                    return "Unknown FamilyName";
            }
        }
        private readonly DeviceItem _device;
 

        public LiveDeviceItem(int familyCode, int address, int optionCode, int ver0, int ver1)
        {
            FamilyCode = familyCode;
            Address = address;
            OptionCode = optionCode;
            Version = "V" + ver1.ToString("X2") + ver0.ToString("X2");

            _device =  Devices.Library.Search(familyCode, optionCode);
            if (_device != null)
            {
                Ports = new List<byte[]>();
                for (int blocks = 0; blocks < _device.Blocks; blocks++)
                    Ports.Add(new byte[_device.BlockSize]);
                Counters = new int[Devices.Library.GetRealyCount(familyCode, optionCode)];
                FirstName = _device.FirstName;
                IsDeviceOk = true;
            }
            else
            {
                _device = Devices.Library.Search(familyCode);
                if (_device != null)
                {
                    Ports = new List<byte[]>();
                    for (int blocks = 0; blocks < _device.Blocks; blocks++)
                        Ports.Add(new byte[_device.BlockSize]);
                    Counters = new int[Devices.Library.GetRealyCount(familyCode)];
                    AppLog.Instance.WriteLine("This device not supported by option " +
                    "OptionCode:" + optionCode.ToString("X2"));
                    FirstName = "This device not supported by option";
                    IsDeviceOk = true;
                }
                else
                {
                    AppLog.Instance.WriteLine("This device not suppoerted: " +
                    "FamilyCode:" + familyCode.ToString("X2") + 
                    "OptionCode:" + optionCode.ToString("X2"));
                    FirstName = "This device not supported.";
                    IsDeviceOk = false;
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
