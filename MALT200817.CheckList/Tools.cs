using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace MALT200817.Checklist
{
    public class Tools
    {
        public static bool IsApplicationInstalled(string p_name)
        {
            string displayName;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                //Console.WriteLine(keyName);
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                //  Console.WriteLine(displayName);
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {

                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                //   Console.WriteLine(displayName);
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // NOT FOUND
            return false;
        }

        public static string GetServiceStatus(string servicename)
        {
            ServiceController sc = new ServiceController(servicename);

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }
        }

        public static bool DoesServiceExist(string serviceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(serviceName));
        }
        /*
        static void GetVersion(string nameToSearch)
        {
            // Get HKEY_LOCAL_MACHINE
            RegistryKey baseRegistryKey = Registry.LocalMachine;

            // If 32-bit OS
            string subKey
            //= "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
            // If 64-bit OS
            = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
            RegistryKey unistallKey = baseRegistryKey.OpenSubKey(subKey);

            string[] allApplications = unistallKey.GetSubKeyNames();
            foreach (string s in allApplications)
            {
                RegistryKey appKey = baseRegistryKey.OpenSubKey(subKey + "\\" + s);
                string appName = (string)appKey.GetValue("DisplayName");
                if (appName == nameToSearch)
                {
                    string appVersion = (string)appKey.GetValue("DisplayVersion");
                    Console.WriteLine("Name:{0}, Version{1}", appName, appVersion);
                    break;
                }


            }

        }

        static void ListAll()
        {
            // Get HKEY_LOCAL_MACHINE
            RegistryKey baseRegistryKey = Registry.LocalMachine;

            // If 32-bit OS
            string subKey
            //= "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
            // If 64-bit OS
            = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
            RegistryKey unistallKey = baseRegistryKey.OpenSubKey(subKey);

            string[] allApplications = unistallKey.GetSubKeyNames();
            foreach (string s in allApplications)
            {
                RegistryKey appKey = baseRegistryKey.OpenSubKey(subKey + "\\" + s);
                string appName = (string)appKey.GetValue("DisplayName");
                string appVersion = (string)appKey.GetValue("DisplayVersion");
                Console.WriteLine("Name:{0}, Version{1}", appName, appVersion);

            }

        }
    }
        */
    }
}
