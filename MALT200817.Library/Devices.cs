

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

        public static Devices Library { get; } = new Devices();

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
                    typeof(ComponentDigitalInput)

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="familyCode">00..FF</param>
        /// <param name="optionCode">00..FF</param>
        /// <returns></returns>
        public DeviceItem Search(string familyCode, string optionCode)
        {
            var retval = this.FirstOrDefault(n => n.FamilyCode == Tools.HexaByteStrToInt(familyCode) &&
                                                  n.OptionCode == Tools.HexaByteStrToInt(optionCode));
            return retval;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="familyCode">0..255</param>
        /// <param name="optionCode">0..255</param>
        /// <returns></returns>
        public DeviceItem Search(int familyCode, int optionCode)
        {
            var retval = this.FirstOrDefault(n => n.FamilyCode == familyCode && n.OptionCode == optionCode);
            return retval;
        }

        public int GetRealyCount(int familyCode, int optionCode)
        {
            var dev = Search(familyCode, optionCode);
            return dev.Components.Count(n => n is ComponentRelaySPDT || n is ComponentRelaySPST );
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
