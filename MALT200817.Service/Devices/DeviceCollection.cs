
namespace MALT200817.Service.Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.IO;


    public class DeviceCollection : BindingList<Device>
    {

        public static byte TpyeCode = 0x05;

        protected override void InsertItem(int index, Device item)
        {
            base.InsertItem(index, item);
        }

        public new void Remove(Device item)
        {
            base.Remove(item);
        }
    }
}
