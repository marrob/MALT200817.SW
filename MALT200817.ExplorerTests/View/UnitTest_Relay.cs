
namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Windows.Forms;


    [TestClass()]
    public class UnitTest_Relay
    {
        [TestMethod()]
        public void Relays_001 ()
        {
            var relays = new ComponentCollection();
            relays.Add(new ComponentItem()  
            {
                RelayLabel = "K1",
                PinLabel_COM = "36",
                PinLabel_NC = "3",
                PinLabel_NO = "67"
            });

            relays.Add(new ComponentItem()
            {
                RelayLabel = "K2",
                PinLabel_COM = "37",
                PinLabel_NC = "4",
                PinLabel_NO = "68"
            });



            var form = new DeviceForm();
            form.Components = relays;
            form.ShowDialog();

        }
    }
}
