using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;
using System.Diagnostics;

namespace _post.setup
{
    class Program
    {
        static void Main(string[] args)
        {
             
            Console.WriteLine("Hello World");
            foreach (string i in args)
            {
                Console.WriteLine(i);
            }
            /*
                        foreach (string i in Tools.RegListPrograms()) {
                            Console.WriteLine(i);
                        }
            */
            /*
                        if(Tools.RegListPrograms().Contains("MALT200817"))
                        {
                            Console.WriteLine("Found it");
                        }
            */
           // Tools.RegListPrograms();

            //Tools.WmiGetProduct("MALT200817");

           // Tools.MsiUninstall("");

           Console.WriteLine( Tools.UninstallString("MALT200817"));

            // "\d+.\d+.\d+.\d+"
            // "\d+.\d+.\d+.\d+"




            Console.Read();
                
        }
    }


    static class Tools
    {

       // https://stackoverflow.com/questions/30067976/programmatically-uninstall-a-software-using-c-sharp/34012614#comment76225434_34012614
        public static void MsiUninstall(string productCode)
        {
            var startInfo = new ProcessStartInfo();

            startInfo.FileName = "msiexec.exe";

            //  msiexec.exe / x { PRODUCT - GUID}

            Process.Start(startInfo);

        }

        public static List<string> RegListPrograms() 
        {
            var programs = new List<string>();
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                Console.WriteLine(key.Name);

                foreach(string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        //var 
                        Console.WriteLine(subkey.GetValue("UninstallString")?.ToString());
                        programs.Add(subkey.GetValue("DisplayName")?.ToString());
                    }
                }
            }

            return programs;
        }
        public static string UninstallString(string displayName)
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
 
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        var progName = subkey.GetValue("DisplayName");
                        if (progName != null)
                        {
                            Debug.WriteLine(progName);
                            if (progName.ToString().Contains(displayName))
                            {
                                var uninstallString = subkey.GetValue("UninstallString")?.ToString();
                                Debug.WriteLine(uninstallString);
                                return uninstallString;
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static void WmiGetProduct(string programName) {

            var mos =  new ManagementObjectSearcher("SELECT * FROM Win32_Product WHERE Name = '" + programName + "'");
            var x = mos.Get();
            Console.WriteLine(x.Count);
        }

    
        public static List<string> WmiListPrograms()
        {
            var programs = new List<string>();

            try
            {
                var mos =  new ManagementObjectSearcher("SELECT * FROM Win32_Product");
                var progs = mos.Get();
                Console.WriteLine(progs.Count);
                foreach (ManagementObject mo in mos.Get())
                {
                    try
                    {
                        //more properties:
                        //http://msdn.microsoft.com/en-us/library/windows/desktop/aa394378(v=vs.85).aspx
                        programs.Add(mo["Name"].ToString());

                    }
                    catch (Exception ex)
                    {
                        //this program may not have a name property
                    }
                }

                return programs;

            }
            catch (Exception ex)
            {
                return programs;
            }
        }

        public static bool Uninstall(ManagementObject mo) 
        {
            object hr = mo.InvokeMethod("Uninstall", null);
            return (bool)hr;
        }
    }
}
