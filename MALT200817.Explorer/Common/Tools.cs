namespace MALT200817.Explorer.Common
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;
    using System.Globalization;
    using System.Diagnostics;
    using System.IO;
    using System.ServiceProcess;
    using System.Linq;

    static class Tools
    {
        public static int HexaByteStrToInt(string value)
        {
            return int.Parse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        public static byte HexaByteStrToByte(string value)
        {
            return byte.Parse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        public static void OpenFolder(string path)
        {
            Process.Start("explorer.exe", path);
        }

        public static void RunNotepadOrNpp(string path)
        {
            var myProcess = new Process();
            myProcess.StartInfo.Arguments = "\"" + path + "\"";
            myProcess.StartInfo.FileName = "Notepad++";
            try
            {
                myProcess.Start();
            }
            catch (Exception)
            {
                myProcess.StartInfo.FileName = "Notepad";
                myProcess.Start();
            }
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

    }
}
