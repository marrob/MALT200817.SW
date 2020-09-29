namespace MALT200817.Configuration
{
    using System;
    public class AppConstants
    {
        public const string SoftwareTitle = "MALT200817.Explorer";
        public const string SoftwareCustomer = "AltonTech";
        public static string AppConfigurationFilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + SoftwareCustomer + "\\" + "MALT200817" + "\\config.xml";
        public static string LibraryDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + SoftwareCustomer + "\\" + "MALT200817" + "\\Library";
        public const string ValueNotAvailable2 = "n/a";
        public const string InvalidFlieNameChar = "A file name can't contain any of flowing characters:";
        
        public const string GenericTimestampFormat = "yyyy.MM.dd HH:mm:ss";
        public const string FileNameTimestampFormat = "yyMMdd_HHmmss";
        public const string FileFilter = "Binary File(*.bin)|*.bin";
        public const string NewLine = "\r\n";
        public const string CsvFileSeparator = ",";
        public static string LogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }
}
