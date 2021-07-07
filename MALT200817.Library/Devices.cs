

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
            if (retval == null)
            {
                retval = this.FirstOrDefault(n => n.FamilyCode == Tools.HexaByteStrToInt(familyCode));
                retval.OptionName = "This device not supported by options";
            }
            return retval;
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
                Add(new DeviceItem().Load(file));
            }
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

        public DeviceItem Search(int familyCode)
        {
            var retval = this.FirstOrDefault(n => n.FamilyCode == familyCode);
            return retval;
        }

        /// <summary>
        /// Vissza adja a szálalóval renedelkező komponensek számát, ezt a library alapján teszi.
        /// </summary>
        /// <param name="familyCode"></param>
        /// <returns>komponensek száma</returns>
        public int GetCountableComponentCount(int familyCode)
        {
            var dev = Search(familyCode);
            return dev.Components.Count(n => (n as IComponentItem).IsCountable);
        }
        /// <summary>
        /// Vissza adja a számlálvóval renedelkező komponensek számát, ezt a library alapján teszi.
        /// </summary>
        /// <param name="familyCode"></param>
        /// <returns>komponensek száma</returns>
        public int GetCountableComponentCount(int familyCode, int optionCode)
        {
            var dev = Search(familyCode, optionCode);
            return dev.Components.Count(n => (n as IComponentItem).IsCountable);
        }
    }
}
