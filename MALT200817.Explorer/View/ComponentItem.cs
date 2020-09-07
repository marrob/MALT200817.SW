
namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public enum ComponetType
    { 
        RELAY_SPDT,
        RELAY_SPST
    }

    public class ComponentItem
    { 
        public string RelayLabel{ get; set; }
        public string PinLabel_NC { get; set; }
        public string PinLabel_NO { get; set; }
        public string PinLabel_COM { get; set; }

        public ComponetType Type { get; set; }
       
    }
}
