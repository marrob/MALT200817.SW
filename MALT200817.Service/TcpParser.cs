
namespace MALT200817.Service
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    using Devices;

    public class TcpParser
    {
        IDeviceExplorer _devExp;

        public TcpParser()
        {
            _devExp = null;
        }

        public TcpParser(IDeviceExplorer explorer)
        {
            _devExp = explorer;
        }

        public string CommandLine(string line)
        {
            line = line.ToUpper();
            line = Regex.Replace(line, @"\s+", " ");


            if (line[0] == '@' && line[3] == '#')
            {
                byte cardType = 0;
                byte addr = 0;
                byte port = 0;

                //@05#01SET01
                var typeStr = line.Substring(1, 2);
                var addrStr = line.Substring(4, 2);
                var command = line.Substring(6);

                if (!byte.TryParse(typeStr.Substring(1), out cardType))
                    return "Data Type Error of 'CARD_TYPE'";

                if (!byte.TryParse(addrStr.Substring(1), out addr))
                    return "Data Type Error of 'ADDR";

                if (command.Contains("SET"))
                {
                    if (!byte.TryParse(command.Substring(3), out port))
                        return "Data Type Error of 'SET'";

                    try
                    {
                        _devExp.RequestOnOne(cardType, addr, port);
                    }
                    catch (ApplicationException ex)
                    {
                        return ex.Message;
                    }
                }
                else if (command.Contains("CLR"))
                {
                    if (!byte.TryParse(command.Substring(2), out port))
                        return "Data Type Error of 'CLR'";

                    try
                    {
                        _devExp.RequestOffOne(cardType, addr, port);
                    }
                    catch (ApplicationException ex)
                    {
                        return ex.Message;
                    }
                }

                return "OK";
            }
            else if (line == "GET-DEVICES")
            {
                string devs = string.Empty;
                foreach (Device dev in _devExp.Devices)
                    devs += dev.ToString() + ",";
                return devs;
            }

            return "Nem kezelet erdemény";
        }

    }
}
