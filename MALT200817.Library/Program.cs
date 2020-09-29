

namespace MALT200817.Library
{


    class Program
    {
        static void Main(string[] args)
        {

            //   Devices.Instance.LoadLibrary(@"C:\ProgramData\AltonTech\MALT200817\Library\");

            DeviceItem di = new DeviceItem();
            di.DefaultWinodwSize = new System.Drawing.Size(10, 12);
            Devices.Library.Save("xx.txt", di);

        }
    }

}