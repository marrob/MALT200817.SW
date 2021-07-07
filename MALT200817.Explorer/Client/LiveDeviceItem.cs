using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Explorer.Client
{
    public class LiveDeviceItem
    {   
        public int FamilyCode { get; set; }
        public string FamilyName { get; set; }
        public int OptionCode { get; set; }
        public int Address { get; set; }
        public string Version { get; set; }
        public string SerialNumber { get; set; }   
        public string OptionName { get; set; }
    }
}
