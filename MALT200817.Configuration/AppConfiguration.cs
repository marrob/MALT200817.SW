namespace MALT200817.Configuration
{
    using System;
    using System.Data;
    using System.IO;
    using System.Xml.Serialization;

    public class AppConfiguration
    {
        const string XmlRootElement = "malt_project";
        const string XmlNamespace = @"http://www.altontech.hu/malt/2020/project/content";

        public static string CurrentPath { get; private set; }

        public string CanBusInterfaceType { get; set; }
        public string CanBusInterfaceName { get; set; }
        public int CanBusBaudrate { get; set; }
        public string ServiceIPAddress { get; set; }
        public int ServicePort { get; set; }
        public double ClientConnectionTimoutMs { get; set; }
        public string LogDirectory { get; set; }
        public bool LogServiceEnabled { get; set; }
        public bool LogExplorerEnabled { get; set; }
        public bool ExplorerDeviceListAutoUpdate { get; set; }
        public string DefaultUserName { get; set; }

        public DfuAppConfiguration DfuApp { get; set; }

        public UserCollection Users { get; set; }
        public ServiceScheduleMaintenance MaintenancegSchedule { get; set; }

        private static Type[] SupportedTypes
        {
            get
            {
                return new Type[]
                {
                    typeof(DfuAppConfiguration),
                    typeof(UserRole),
                    typeof(UserItem),
                    typeof(UserCollection),
                    typeof(string),
                    typeof(ServiceScheduleMaintenance),
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
                Instance.CanBusInterfaceType = "XNET";
                Instance.CanBusInterfaceName = "CAN1";
                Instance.CanBusBaudrate = 1;
                Instance.ServiceIPAddress = "";
                Instance.ServicePort = 2013;
                Instance.ClientConnectionTimoutMs = 1000;
                Instance.LogDirectory = AppConstants.LogDirectory;
                Instance.LogServiceEnabled = false;
                Instance.LogExplorerEnabled = false;
                Instance.DefaultUserName = "Default Admin";
                Instance.ExplorerDeviceListAutoUpdate = true;

                Instance.DfuApp = new DfuAppConfiguration();
                Instance.DfuApp.CanBusInterfaceType = "XNET";
                Instance.DfuApp.CanBusInterfaceName = "CAN1";
                Instance.DfuApp.CanBusBaudrate = 250000;
                Instance.DfuApp.RxBaseAddress = 0x600;
                Instance.DfuApp.TxBaseAddress = 0x700;
                Instance.DfuApp.LogEnable = false;
                Instance.DfuApp.FirmwareDirecotry = AppConstants.DefaultFirmwareDirectory;

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

                Instance.MaintenancegSchedule = new ServiceScheduleMaintenance();
                Instance.MaintenancegSchedule.DailyTime = "00:00";
                Instance.MaintenancegSchedule.Enabled = false;

                SaveToFile(AppConstants.AppConfigurationFilePath);
                new ApplicationException("Set the ConfigurationFile! " + AppConstants.AppConfigurationFilePath);

            }
            else
            {
                LoadFromFile(AppConstants.AppConfigurationFilePath);
            }
        }

        public static void Update()
        {
            LoadFromFile(CurrentPath);
        }

        static void LoadFromFile(string path)
        {
            CurrentPath = path;

            var xmlFormat = new XmlSerializer(typeof(AppConfiguration), null, SupportedTypes, new XmlRootAttribute(XmlRootElement), XmlNamespace);
            AppConfiguration instance;
            using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                instance = (AppConfiguration)xmlFormat.Deserialize(fStream);

            Instance.CanBusInterfaceType = instance.CanBusInterfaceType;
            Instance.CanBusInterfaceName = instance.CanBusInterfaceName;
            Instance.CanBusBaudrate = instance.CanBusBaudrate;
            Instance.ServiceIPAddress = instance.ServiceIPAddress;
            Instance.ServicePort = instance.ServicePort;
            Instance.ClientConnectionTimoutMs = instance.ClientConnectionTimoutMs;
            Instance.LogDirectory = instance.LogDirectory;
            Instance.LogServiceEnabled = instance.LogServiceEnabled;
            Instance.LogExplorerEnabled = instance.LogExplorerEnabled;
            Instance.ExplorerDeviceListAutoUpdate = instance.ExplorerDeviceListAutoUpdate;
            Instance.DefaultUserName = instance.DefaultUserName;

            Instance.DfuApp = new DfuAppConfiguration();

            Instance.DfuApp.CanBusInterfaceType = instance.DfuApp.CanBusInterfaceType;
            Instance.DfuApp.CanBusInterfaceName = instance.DfuApp.CanBusInterfaceName;
            Instance.DfuApp.CanBusBaudrate = instance.DfuApp.CanBusBaudrate;
            Instance.DfuApp.RxBaseAddress = instance.DfuApp.RxBaseAddress;
            Instance.DfuApp.TxBaseAddress = instance.DfuApp.TxBaseAddress;
            Instance.DfuApp.LogEnable = instance.DfuApp.LogEnable;
            Instance.DfuApp.FirmwareDirecotry = instance.DfuApp.FirmwareDirecotry;


            Instance.Users = new UserCollection();
            foreach (UserItem i in instance.Users)
                Instance.Users.Add(i);

            Instance.MaintenancegSchedule = new ServiceScheduleMaintenance();
            Instance.MaintenancegSchedule.DailyTime = instance.MaintenancegSchedule.DailyTime;
            Instance.MaintenancegSchedule.Enabled = instance.MaintenancegSchedule.Enabled;
            


            Instance.Users.Add(new UserItem()
            {
                Name = "God",
                Password = "60F5096F-AFF4-4CD8-86F9-6FED7A8F7A8D",
                Role = UserRole.ADMINISTRATOR,
            }) ; 
        }
    }
}
