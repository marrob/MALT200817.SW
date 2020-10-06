using Microsoft.VisualStudio.TestTools.UnitTesting;
using MALT200817.Explorer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MALT200817.Explorer.Client;

namespace MALT200817.Explorer.View.Tests
{
    [TestClass()]
    public class DeviceCooridnatorTests
    {
        LiveDeviceCollection _devices = new LiveDeviceCollection();

        [TestInitialize]
        public void Init()
        {
           
            _devices.Add(new LiveDeviceItem()
            {
                FamilyCode = 0x03,
                OptionCode = 0x00,
                Address = 0x01,
                Version = "0.00",
                SerialNumber = "123456"
            });
            _devices.Add(new LiveDeviceItem()
            {
                FamilyCode = 0x03,
                OptionCode = 0x01,
                Address = 0x01,
                Version = "0.01",
                SerialNumber = "666"
            });
            _devices.Add(new LiveDeviceItem()
            {
                FamilyCode = 0x15,
                OptionCode = 0x05,
                Address = 0x03,
                Version = "0.02",
                SerialNumber = "999"
            });
        }

        [TestMethod()]
        public void ShowSelectedDeviceTest()
        {
            var frm = new MainForm();
            var dp = new DevicePresenter(frm.DevicesDgv);
            frm.Load += (sender, e) => (sender as MainForm).Visible = true;
            frm.ShowDialog();
        
        }
    }
}