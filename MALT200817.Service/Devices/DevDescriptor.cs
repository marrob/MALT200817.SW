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
                CardType = 0x03,
                Options = 0x00,
                CardName = "MALT132",
                Blocks = 1,
                BytePerBlock = 8,
                TotalPort = 32
            });
            this.Add(new DeviceDescriptor()
            {
                CardType = 0xFF,
                Options = 0x00,
                CardName = "NOT SUPPORTED",
                Blocks = 0,
                BytePerBlock = 0,
                TotalPort = 0
            });
        }

    }
    public class DeviceDescriptor
    {

        public int CardType;
        public int Options;
        public string PK { get {return "@" + CardType.ToString("X2") + "O" + Options.ToString("X2"); } }
        public string CardName;
        public int Blocks;
        public int BytePerBlock;
        public int TotalPort;
    }
}
