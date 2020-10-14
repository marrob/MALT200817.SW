
namespace Konvolucio.MUDS150628
{
    using System;
    using System.IO;
    using System.Text;

    internal class AppLog
    {
        public static AppLog Instance { get; } = new AppLog();

        public string FilePath { get; set; }
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
            try
            {
                if (Enabled)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                    {
                        Enabled = false;
                    }
                    else
                    {
                        line = DateTime.Now.ToString(Constants.GenericTimestampFormat, System.Globalization.CultureInfo.InvariantCulture) + ";" + line + Constants.NewLine;
                        var fileWrite = new StreamWriter(FilePath, true, Encoding.ASCII);
                        fileWrite.NewLine = Constants.NewLine;
                        fileWrite.Write(line);
                        fileWrite.Flush();
                        fileWrite.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Enabled = false;
                throw new IOException("Cannot write to log file, please check the path.\r\n" + ex.Message);
            }
        }
    }
}
