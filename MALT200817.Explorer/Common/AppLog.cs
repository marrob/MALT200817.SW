
namespace MALT200817.Explorer.Common
{
    using System;
    using System.IO;
    using System.Text;

    public class AppLog
    {
        public static AppLog Instance { get; } = new AppLog();

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

        public AppLog()
        {
            Enabled = true;
            FilePath = "IoLog.txt";
        }

        public void WriteLine(string line)
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
