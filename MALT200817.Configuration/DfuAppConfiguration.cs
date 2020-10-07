
namespace MALT200817.Configuration
{
    public class DfuAppConfiguration
    {
        public string CanBusInterfaceType { get; set; }
        public string CanBusInterfaceName { get; set; }
        public int TxBaseAddress { get; set; }
        public int RxBaseAddress { get; set; }
        public int CanBusBaudrate { get; set; }
        public bool LogEnable { get; set; }
        public string FirmwareDirecotry { get; set; }
    }
}
