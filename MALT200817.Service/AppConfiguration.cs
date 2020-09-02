namespace MALT200817.Service
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class AppConfiguration
    {
        const string XmlRootElement = "malt_project";
        const string XmlNamespace = @"http://www.altontech.hu/malt/2020/project/content";

   
        public string CanInterfaceType { get; set; }
        public string CanInterfaceName { get; set; }

        public string ServiceHostame { get; set; }
        public int Baudrate { get; set; }
        public bool CanIoLog { get; set; }
        public string AppLogPath { get; set; }
        public bool AppLogEnabled { get; set; }

        private static Type[] SupportedTypes
        {
            get
            {
                return new Type[]
                {
                    typeof(string),
                };
            }
        }

        public AppConfiguration()
        {
            CanInterfaceType = "Please set the interface type eg.:XNET, NICAN...";
            CanInterfaceName = "Please set the interface eg.: CAN1, CAN0...";
            Baudrate = 1;
            CanIoLog = false;
            AppLogPath = "";
            AppLogEnabled = false;
        }

        public static AppConfiguration Instance { get; } = new AppConfiguration();

        public static void SaveToFile(string path)
        {
            var xmlFormat = new XmlSerializer(typeof(AppConfiguration), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, Instance);
            }
        }

        public static void LoadFromFile(string path)
        {
            var xmlFormat = new XmlSerializer(typeof(AppConfiguration), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            AppConfiguration instance;
            using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                instance = (AppConfiguration)xmlFormat.Deserialize(fStream);

            Instance.CanInterfaceType = instance.CanInterfaceType;
            Instance.CanInterfaceName = instance.CanInterfaceName;
            Instance.Baudrate = instance.Baudrate;
            Instance.CanIoLog = instance.CanIoLog;
            Instance.AppLogPath = instance.AppLogPath;
            Instance.AppLogEnabled = instance.AppLogEnabled;

        }
    }
}
