
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
        /*
         *Az elsö bájt legkisebb helyiértéke az első port
         *A lista egy sora egy block (ami 4 bájt), ennyi fér bele egy CAN üzenetbe.
         *A blockok száma (lista sorai) nincsenek maximializáva)
         */
        public List<byte[]> OutputPorts { get; private set; } 
        public List<byte[]> InputPorts { get; private set; } /*Az elsö bájt legkisebb helyiértéke az első port*/
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
                    return "Error Unknown Family Name";
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
                OutputPorts = new List<byte[]>();
                for (int blocks = 0; blocks < _device.OutputBlocks; blocks++)
                    OutputPorts.Add(new byte[_device.BlockSize]);

                InputPorts = new List<byte[]>();
                for (int blocks = 0; blocks < _device.InputBlocks; blocks++)
                    InputPorts.Add(new byte[_device.BlockSize]);


                Counters = new int[Devices.Library.GetCountableComponentCount(familyCode, optionCode)];
                FirstName = _device.OptionName;
                IsDeviceOk = true;
            }
            else
            {
                _device = Devices.Library.Search(familyCode);
                if (_device != null)
                {
                    OutputPorts = new List<byte[]>();
                    for (int blocks = 0; blocks < _device.OutputBlocks; blocks++)
                        OutputPorts.Add(new byte[_device.BlockSize]);
                    Counters = new int[Devices.Library.GetCountableComponentCount(familyCode)];
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

        public void UpdateOutputPortsStatus(int block, byte[] ports)
        {
            if (OutputPorts != null)
                Array.Copy(ports, OutputPorts[block], ports.Length);            
        }

        public void UpdateInputPortsStatus(int block, byte[] ports)
        {
            if (OutputPorts != null)
                Array.Copy(ports, InputPorts[block], ports.Length);
        }

        public void SetSerialNumber(byte[] serialNumByteArray)
        {
            SerialNumber = BitConverter.ToInt32(serialNumByteArray, 0).ToString();
        }
    }
}
