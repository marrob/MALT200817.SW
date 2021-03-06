﻿
namespace MALT200817.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.IO;


    public class LiveDeviceCollection : BindingList<LiveDeviceItem>
    {

        protected override void InsertItem(int index, LiveDeviceItem item)
        {
            base.InsertItem(index, item);
        }

        public new void Remove(LiveDeviceItem item)
        {
            base.Remove(item);
        }

        public void SetOne(int cardType, int address, int port)
        {

        }

        public LiveDeviceItem Search(byte familyCode, byte address)
        {
            return this.FirstOrDefault(n => n.FamilyCode == familyCode && n.Address == address);
        }
    }
}
