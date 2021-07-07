

using System.Drawing;
using System.Dynamic;

namespace MALT200817.Library
{


    class Program
    {
        static void Main(string[] args)
        {

            //   Devices.Instance.LoadLibrary(@"C:\ProgramData\AltonTech\MALT200817\Library\");

            new App();

        }
    }

    class App
    {

        public App()
        {
           GenerateMAL160T();
        }

        void GenerateMAL160T()
        {

            var device = new DeviceItem();
            device.LibVersion = @"¯\_(ツ)_/¯";
            device.FamilyName = "MALT160T";
            device.FamilyCode = 21;
            device.OptionCode = 5;
            device.BlockSize = 4;
            device.OutputBlocks = 5;
            device.OptionName = "MALT160T";
            device.DefaultWinodwSize = new Size(455, 783);
            device.Components = new ComponentCollection();

            int port = 1;
            int NoA = 3;
            int NoB = 67;
            int NoC = 36;


            do
            {
                device.Components.Add(new ComponentRelaySPST()
                {
                    Port = port,
                    Label = "K" + port,
                    PinLabel_COM = "30",
                    PinLabel_NO = (NoA++).ToString(),
                });
                port++;
                if (port > 80)
                    break;

                device.Components.Add(new ComponentRelaySPST()
                {
                    Port = port,
                    Label = "K" + port,
                    PinLabel_COM = "30",
                    PinLabel_NO = (NoB++).ToString(),
                });
                port++;
                if (port > 80)
                    break;

                device.Components.Add(new ComponentRelaySPST()
                {
                    Port = port,
                    Label = "K" + port,
                    PinLabel_COM = "30",
                    PinLabel_NO = (NoC++).ToString(),
                });
                port++;
                if (port > 80)
                    break;

            } while (port <= 80);

            //port = 1;
            NoA = 3;
            NoB = 67;
            NoC = 36;

            do
            {
                device.Components.Add(new ComponentRelaySPST()
                {
                    Port = port,
                    Label = "K" + port,
                    PinLabel_COM = "94",
                    PinLabel_NO = (NoA++).ToString(),
                });
                port++;
                if (port > 160)
                    break;

                device.Components.Add(new ComponentRelaySPST()
                {
                    Port = port,
                    Label = "K" + port,
                    PinLabel_COM = "94",
                    PinLabel_NO = (NoB++).ToString(),
                });
                port++;
                if (port > 160)
                    break;

                device.Components.Add(new ComponentRelaySPST()
                {
                    Port = port,
                    Label = "K" + port,
                    PinLabel_COM = "94",
                    PinLabel_NO = (NoC++).ToString(),
                });
                port++;
                if (port > 160)
                    break;

            } while (port <= 160);


            device.Save("c:\\Users\\Margit Robert\\Documents\\proba.xml");

        }
    }
}