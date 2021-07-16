using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;


namespace Konvolucio.PostBuildTool
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---------------Build Post Action Tool------------------");
            string assamblyPath = @"D:\@@@!ProjectS\KonvolucioApp\MALT200817.SW\GlobalAssemblyInfo.cs";
            string msiFileName = "MALT200817.Setup";
            string msiPath = @"D:\@@@!ProjectS\KonvolucioApp\MALT200817.SW\MALT200817.Setup\bin\Release\" + msiFileName + ".msi";
            string prgDisplayName = "MALT200817";
            // string manualPath = @"D:\angular\marrob.github.io\";
            string appExplorerPath = @"C:\Program Files (x86)\AltonTech\MALT200817.Explorer\MALT200817.Explorer.exe";
            string lvlibPath = @"D:\@@@!ProjectS\KonvolucioApp\MALT200817.SW\MALT200817.LabView.Driver\AltonTech MALT200817.lvlib";





            /*------------------------------------------------------------------------*/
            Console.WriteLine("Assembly módosítása folyamatban...");
            /*
             * 
             * using System.Reflection;
             * [assembly: AssemblyVersion("0.0.0.85")]
             * [assembly: AssemblyFileVersion("0.0.0.85")]
             * 
             */
            string assamblyText = Tools.ReadFile(assamblyPath);
            string version = Tools.GetAssemblyVersion(assamblyText);


            string assamblyResult = Tools.IncraseAssamblyBuildNumber(assamblyText);
            string incVersion = Tools.GetAssemblyVersion(assamblyResult);
            Tools.WriteFile(assamblyResult, assamblyPath);
            
            Console.WriteLine("Assembly sikeresen módosítva. Következő fordítás AssemblyVersion:" + incVersion);
            Console.WriteLine("Jelenlegi fordítás AssemblyVersion:" + version);

            string targetMsiPath = Path.GetDirectoryName(msiPath) + "\\" + msiFileName + "_" + version + ".msi";

            if (File.Exists(targetMsiPath)) { 
                File.Delete(targetMsiPath);
                Console.WriteLine("A cél MSI fájl már létezett, ezért töröltem itt:" + msiFileName + "_" + version);
            }

            /*------------------------------------------------------------------------*/
            Console.WriteLine("lvlib fájl beolvasása");
            string lvlibString = Tools.ReadFile(lvlibPath);
            Console.WriteLine("lvlib fájl verzió módosítása, ami a kövektező verzióban fog érvényesűlni");
            string lvlibUpdated = Tools.SetNiLibVersion(lvlibString, incVersion);
            Console.WriteLine("lvlib fájlba írása");
            Tools.WriteFile(lvlibUpdated, lvlibPath);

            /*------------------------------------------------------------------------*/
            if (!File.Exists(msiPath))
            {
                Console.WriteLine("A forrás MSI fájl nem létezik, fordítsd le előtte!");
                goto CpltFailed;
            }
            else
            {
                File.Copy(msiPath, targetMsiPath);
                Console.WriteLine("Az új MSI fájl elkészült, AssemblyVersion:" + msiFileName + "_" + version);
            }


            /*------------------------------------------------------------------------*/
            string uninstallString = Tools.UninstallString(prgDisplayName);

            if (string.IsNullOrEmpty(uninstallString))
            {
                Console.WriteLine(prgDisplayName + " alkalmazás nincs telepítve");
            }
            else 
            {
                Console.WriteLine("Az régi alaklmazás törlése folyamatban, UninstallString:" + uninstallString);
                Tools.MsiUninstall(prgDisplayName);
                Console.WriteLine("Az régi alaklmazás törölve");
            }

            /*------------------------------------------------------------------------*/
            Console.WriteLine("MSI telepítése folyamatban...");
            Tools.MsiInstall(targetMsiPath);
            Console.WriteLine("MSI telepítése kész...");

            /*------------------------------------------------------------------------*/
            Console.WriteLine("Explorer indítása");
            Tools.RunApp(appExplorerPath);


            Console.WriteLine("OK...");
            goto Cplt;

    CpltFailed:
            Console.WriteLine("FAIL");

    Cplt:  
            Console.Read();
                
        }
    }


    public static class Tools
    {

        public static string IncraseAssamblyBuildNumber(string assembly)
        {
            var rx = new Regex(@"\d+.(\d+).\d+.(?<build>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(assembly);
            //Console.WriteLine("{0} matches found in:\n   {1}", matches.Count, text);

            string version = string.Empty;
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                //Console.WriteLine("'{0}' repeated at positions {1} and {2}", groups["build"].Value, groups[0].Index, groups[1].Index);
                version = groups["build"].Value;
            }

            string result = string.Empty;
            if (!string.IsNullOrEmpty(version))
            {
                int build = int.Parse(version);
                build++;
                result = assembly.Replace(version, build.ToString());
            }
            return result;
        }

        public static string SetNiLibVersion(string lvlib, string version)
        {

            /*<Property Name="NI.Lib.Version" Type="Str">1.0.0.0</Property>*/
            var rx = new Regex("<Property Name=\"NI.Lib.Version\" Type=\"Str\">(?<version>\\d+.\\d+.\\d+.\\d+)</Property>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Match match = rx.Match(lvlib);
            string result = string.Empty;
            if (match.Success) {
                return lvlib.Replace(match.Groups["version"].Value, version);
            }
            return result;
        }

        public static string GetAssemblyVersion(string text)
        {
            /* using System.Reflection;
             * [assembly: AssemblyVersion("0.0.0.85")]
             * [assembly: AssemblyFileVersion("0.0.0.85")]*/
            Regex rx = new Regex(@"(\d+.\d+.\d+.\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Match match = rx.Match(text);
            string result = string.Empty;
            if (match.Success)
                result = match.Value;
            return result;
        }

        public static void MsiUninstall(string displayName)
        {
            //msiexec.exe / x { PRODUCT - GUID}
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "MsiExec.exe";
            startInfo.Arguments = Tools.UninstallString(displayName);
            var process = Process.Start(startInfo);
            process.WaitForExit();
        }

        public static void MsiInstall(string msiPath)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.Arguments = @"/i " + msiPath; //+ "/q";
            startInfo.FileName = "MsiExec.exe";
            var process = Process.Start(startInfo);
            process.WaitForExit();
        }

        public static void RunApp(string displayName)
        {
            Process process = new Process();
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = displayName;
            process.StartInfo = processInfo;
            process.Start();

        }

        public static string ReadFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File does not exits", path);

            String line = string.Empty;
            using (StreamReader sr = new StreamReader(path, Encoding.ASCII))
                line = sr.ReadToEnd();

            return line;
        }

        public static void WriteFile(string text, string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File does not exits", path);
            using (StreamWriter sw = new StreamWriter(path, false))
                sw.WriteLine(text);
        }

        public static List<string> RegListPrograms()
        {
            var programs = new List<string>();
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                Console.WriteLine(key.Name);

                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        programs.Add(subkey.GetValue("DisplayName")?.ToString());
                    }
                }
            }
            return programs;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/6345262/get-product-code-of-installed-msi
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
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
                                string uninstallString = subkey.GetValue("UninstallString")?.ToString();
                                uninstallString = uninstallString.Replace("/I", "/X");
                                uninstallString = uninstallString.Replace("MsiExec.exe", "").Trim();
                                // uninstallString += " /quiet /qn";
                                return uninstallString;
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }
    }


}
