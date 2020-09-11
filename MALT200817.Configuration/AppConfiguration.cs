namespace MALT200817.Configuration
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class AppConfiguration
    {
        const string XmlRootElement = "malt_project";
        const string XmlNamespace = @"http://www.altontech.hu/malt/2020/project/content";

        public string CanBusInterfaceType { get; set; }
        public string CanBusInterfaceName { get; set; }
        public int CanBusBaudrate { get; set; }
        public string ServiceIPAddress { get; set; }
        public int ServicePort { get; set; }
        public string LogDirectory { get; set; }
        public bool LogServiceEnabled { get; set; }
        public bool LogExplorerEnabled { get; set; }



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
            CanBusInterfaceType = "Please set the interface type eg.:XNET, NICAN...";
            CanBusInterfaceName = "Please set the interface eg.: CAN1, CAN0...";
            CanBusBaudrate = 1;
            ServiceIPAddress = "";
            ServicePort = 2013;
            LogDirectory = AppConstants.LogDirectory;
            LogServiceEnabled = false;
            LogExplorerEnabled = false;

        }

        public static AppConfiguration Instance { get; } = new AppConfiguration();

        static void SaveToFile(string path)
        {
            var xmlFormat = new XmlSerializer(typeof(AppConfiguration), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, Instance);
            }
        }

        public static void Init()
        {
            if (!File.Exists(AppConstants.AppConfigurationFilePath))
            {
                AppConfiguration.SaveToFile(AppConstants.AppConfigurationFilePath);
                new ApplicationException("Set the ConfigurationFile! " + AppConstants.AppConfigurationFilePath);
            }
            else
            {
                AppConfiguration.LoadFromFile(AppConstants.AppConfigurationFilePath);
            }
        }

        static void LoadFromFile(string path)
        {
            var xmlFormat = new XmlSerializer(typeof(AppConfiguration), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            AppConfiguration instance;
            using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                instance = (AppConfiguration)xmlFormat.Deserialize(fStream);

            Instance.CanBusInterfaceType = instance.CanBusInterfaceType;
            Instance.CanBusInterfaceName = instance.CanBusInterfaceName;
            Instance.CanBusBaudrate = instance.CanBusBaudrate;
            Instance.ServiceIPAddress = instance.ServiceIPAddress;
            Instance.ServicePort = instance.ServicePort;
            Instance.LogDirectory = instance.LogDirectory;
            Instance.LogServiceEnabled = instance.LogServiceEnabled;
            Instance.LogExplorerEnabled = instance.LogExplorerEnabled;
        }
    }
}
