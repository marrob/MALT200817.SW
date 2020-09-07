
namespace MALT200817.Service.Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.IO;


    public class DeviceCollection : BindingList<DeviceItem>
    {

        protected override void InsertItem(int index, DeviceItem item)
        {
            base.InsertItem(index, item);
        }

        public new void Remove(DeviceItem item)
        {
            base.Remove(item);
        }

        public void SetOne(int cardType, int address, int port)
        {

        }

        public DeviceItem Search(byte cardType, byte address)
        {
            return this.FirstOrDefault(n => n.FamilyCode == cardType && n.Address == address);
        }
    }
}
