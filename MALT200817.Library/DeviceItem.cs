﻿

namespace MALT200817.Library
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;


    public class DeviceItem
    {
        const string XmlRootElement = "malt_device";
        const string XmlNamespace = @"http://www.altontech.hu/malt/2020/project/content";

        [XmlIgnore]
        public string Path { get; set; }
        public string LibVersion { get; set; }
        public string FamilyName { get; set; }
        public int FamilyCode { get; set; }
        public string OptionName { get; set; }
        public int OptionCode { get; set; }
        public int BlockSize { get; set; }
        /// <summary>
        /// Kimineit blokok száma, alaphelyzetben 1 blokk 4 *8bit széles = 32port/block
        /// A relékártyának output blokaji vannak
        /// </summary>
        public int OutputBlocks { get; set; }
        public int InputBlocks { get; set; }
        public Size DefaultWinodwSize { get; set; }
        public ComponentCollection Components {get; set;}

        public DeviceItem()
        {
        }


        private static Type[] SupportedTypes
        {
            get
            {
                return new Type[]
                {
                    typeof(string),
                    typeof(ComponentCollection),
                    typeof(ComponentRelaySPDT),
                    typeof(ComponentRelaySPST),
                    typeof(ComponentDigitalOutput),
                    typeof(ComponentDigitalInput),
                    typeof(ComponentCoil)

                };
            }
        }


        public void Save(string path)
        {
            var xmlFormat = new XmlSerializer(typeof(DeviceItem), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, this);
            }
        }


        public DeviceItem Load(string path)
        {
            try
            {
                var xmlFormat = new XmlSerializer(typeof(DeviceItem), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
                DeviceItem instance;
                using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    instance = (DeviceItem)xmlFormat.Deserialize(fStream);

                instance.Path = path;
                LibVersion = instance.LibVersion;
                FamilyName = instance.FamilyName;
                FamilyCode = instance.FamilyCode;
                OptionCode = instance.OptionCode;
                OptionName = instance.OptionName;
                BlockSize = instance.BlockSize;
                OutputBlocks = instance.OutputBlocks;
                InputBlocks = instance.InputBlocks;
                Components = new ComponentCollection();
                foreach (object i in instance.Components)
                    Components.Add(i);
                DefaultWinodwSize = instance.DefaultWinodwSize;
            }
            catch (Exception ex)
            {
                throw new Exception("Library loading error when try load\r\n" + path + "\r\n" + ex.Message);
                
            }
           return this;
           

        }
    }
}
