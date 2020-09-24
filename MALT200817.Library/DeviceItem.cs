

namespace MALT200817.Library
{
    using System.Drawing;
    using System.Xml.Serialization;

    public class DeviceItem
    {
        [XmlIgnore]
        public string Path { get; set; }
        public string LibVersion { get; set; }
        public string FamilyName { get; set; }
        public int FamilyCode { get; set; }
        public int OptionCode { get; set; }
        public string FirstName { get; set; }
        public int BlockSize { get; set; }
        public int Blocks { get; set; }
        public ComponentCollection Components {get; set;}
        public Size DefaultWinodwSize { get; set; }

        public DeviceItem()
        {
        }
    }
}
