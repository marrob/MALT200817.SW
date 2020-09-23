

namespace MALT200817.Library
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class Devices : BindingList<DeviceItem>
    {
        const string XmlRootElement = "malt_device";
        const string XmlNamespace = @"http://www.altontech.hu/malt/2020/project/content";

        public static Devices Instance { get; } = new Devices();

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
                };
            }
        }


        public void Save(string path, DeviceItem device)
        {
            var xmlFormat = new XmlSerializer(typeof(DeviceItem), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, device);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void LoadLibrary(string path)
        {
            this.Clear();
            var files = Directory.GetFiles(path);
            foreach (string file in files)
            {
               Load(file);
            }
        }


        public DeviceItem Search(int familyCode, int optionCode)
        {
            var retval = this.FirstOrDefault(n => n.FamilyCode == familyCode && n.OptionCode == optionCode);
            return retval;
        }


        void Load(string path)
        {
            var xmlFormat = new XmlSerializer(typeof(DeviceItem), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            DeviceItem instance;
            using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                instance = (DeviceItem)xmlFormat.Deserialize(fStream);
            this.Add(instance);
            instance.Path = path;
        }

    }
}
