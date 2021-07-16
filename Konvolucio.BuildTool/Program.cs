using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace Konvolucio.BuildTool
{

    class Program
    {
        static void Main(string[] args)
        {
        }
    }


     public static class Tools
    {

        public static string IncraseAssamblyBuildNumber(string text)
        {
            Regex rx = new Regex(@"\d+.(\d+).\d+.(?<build>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(text);
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
                result = text.Replace(version, build.ToString());
            }
            return result;
        }

        public static string GetAssemblyVersion(string text)
        {
            Regex rx = new Regex(@"(?<version>\d+.\d+.\d+.\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(text);

            string version = string.Empty;
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                version = groups["version"].Value;
                break;
            }
            return version;
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
