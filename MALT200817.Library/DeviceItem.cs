

namespace MALT200817.Library
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
        public ComponentCollection Components {get; set;}
        public Size DefaultWinodwSize { get; set; }

        public DeviceItem()
        {
        }
    }
}
