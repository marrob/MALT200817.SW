using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Service.Devices
{


    public class  DevicesDesciptor : List<DeviceDescriptor>   
    {

        public static DevicesDesciptor Instance { get; } = new DevicesDesciptor();

        public DevicesDesciptor()
        {
            this.Add(new DeviceDescriptor()
            {
                FamilyCode = 0xFF,
                OptionCode = 0x00,
                FamilyName = "NOT SUPPORTED",
                Blocks = 0,
                BytePerBlock = 0,
                TotalPort = 0
            });

            this.Add(new DeviceDescriptor()
            {
                FamilyCode = 0x03,
                OptionCode = 0x00,
                FamilyName = "MALT132",
                Blocks = 1,
                BytePerBlock = 4,
                TotalPort = 32
            });

            this.Add(new DeviceDescriptor()
            {
                FamilyCode = 0x15,
                OptionCode = 0x00,
                FamilyName = "MALT160T",
                Blocks = 4,
                BytePerBlock = 4,
                TotalPort = 160
            });

        }

    }
    public class DeviceDescriptor
    {

        public int FamilyCode;
        public int OptionCode;
        public string PK { get { return "@" + FamilyCode.ToString("X2"); } }
        public string FamilyName;
        public int Blocks;
        public int BytePerBlock;
        public int TotalPort;
    }
}
