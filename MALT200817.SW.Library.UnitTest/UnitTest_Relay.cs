
namespace MALT200817.Library
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
 

    [TestClass()]
    public class UnitTest_Relay
    {
        [TestMethod()]
        public void Relays_001 ()
        {
            var relays = new ComponentCollection();
            relays.Add(new ComponentRelaySPDT()
            {
                Label = "K1",
                PinLabel_COM = "36",
                PinLabel_NC = "3",
                PinLabel_NO = "67"
            });

            relays.Add(new ComponentRelaySPDT()
            {
                Label = "K2",
                PinLabel_COM = "37",
                PinLabel_NC = "4",
                PinLabel_NO = "68"
            });
        }
    }
}
