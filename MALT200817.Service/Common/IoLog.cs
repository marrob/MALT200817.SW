
namespace MALT200817.Service.Common
{
    using System;
    using System.IO;
    using System.Text;

    public class IoLog
    {
        public static IoLog Instance { get; } = new IoLog();

        public string FilePath { get; set; } = AppConstants.LogPath;
        public bool Enabled;

        public double? GetFileSizeKB
        {
            get
            {
                if (File.Exists(FilePath))
                {
                    FileInfo fi = new FileInfo(FilePath);
                    return fi.Length / 1024;
                }
                else
                    return null;
            }
        }

        public IoLog()
        {
            Enabled = true;
            FilePath = "IoLog.txt";
        }

        public void WirteLine(string line)
        {
            if (Enabled)
            {
                line = DateTime.Now.ToString(AppConstants.GenericTimestampFormat, System.Globalization.CultureInfo.InvariantCulture) + ";" + line + AppConstants.NewLine;
                var fileWrite = new StreamWriter(FilePath, true, Encoding.ASCII);
                fileWrite.NewLine = AppConstants.NewLine;
                fileWrite.Write(line);
                fileWrite.Flush();
                fileWrite.Close();
            }
        }
    }
}
