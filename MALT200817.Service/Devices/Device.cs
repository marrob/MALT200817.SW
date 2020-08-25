

namespace MALT200817.Service.Devices
{
    public class Device
    {
        public int Type { get; set; }
        public int Address { get; set; }
        public int Options { get; set; }
        public string Version { get; set; }


        public Device(int type, int address, int options, int ver0, int ver1)
        {
            Type = type;
            Address = address;
            Options = options;
            Version = "V" + ver1.ToString("X2") + ver0.ToString("X2");
        }


        public override string ToString()
        {
            return "@" + Type.ToString("X2") + "#" +  Address.ToString("X2") + "O" + Options.ToString("X2") + Version;

        }
    }
}
