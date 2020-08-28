
namespace MALT200817.Service
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    using Devices;
    using System.Xml.Schema;
    using System.Globalization;
    using Common;

    public class TcpParser
    {
        IExplorer _devExp;

        public TcpParser()
        {
            _devExp = null;
        }

        public TcpParser(IExplorer explorer)
        {
            _devExp = explorer;
        }

        public string CommandLine(string line)
        {
            line = line.ToUpper();
            line = Regex.Replace(line, @"\s+", " ");

            if (line == "SAY_HELLO_WOLRD")
            {
                return "HELLO WORLD";
            }
            else if (line == "*OPC?")
            {
                return "OPC";
            }
            else if (line[0] == '@')
            {
                byte cardType = 0;
                byte addr = 0;
                byte port = 0;

                //@05:01:SET:01
                var parts = line.Substring(1).Split(':');
                var typeStr = parts[0];
                var addrStr = parts[1];
                var command = parts[2];
                var valueStr = parts[3];

                if (!byte.TryParse(typeStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out cardType))
                    return "!Data Type Error of 'CARD_TYPE'";


                if (!byte.TryParse(addrStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out addr))
                    return "!Data Type Error of 'ADDR";

                if (command == "SET")
                {
                    _devExp.RequestSetOne(cardType, addr,
                        byte.Parse(valueStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                }
                else if (command == "CLR")
                {
                    _devExp.RequestClrOne(cardType, addr,
                        byte.Parse(valueStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                }
                else if (command == "CLRS")
                {
                    _devExp.RequestClrSeveral(cardType, addr, Tools.ConvertHexStringToByteArray(valueStr));
                }
                else if (command == "SETS")
                {
                    _devExp.RequestSetSeveral(cardType, addr, Tools.ConvertHexStringToByteArray(valueStr));
                }
                else if (command == "GET")
                {
                    if (!byte.TryParse(valueStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out port))
                        return "!Data Type Error of " + command;
                    var retval = "@" + cardType.ToString("X2") + ":" + addr.ToString("X2") + ":STA:" + port.ToString("X2");
                    if (_devExp.RequestGetOne(cardType, addr, (byte)(port - 1)))
                        retval += ":SET";
                    else
                        retval += ":CLR";
                    return retval;
                }
                return "OK";
            }
            
            else if (line == "GET:DEVICES")
            {
                string devs = string.Empty;
                foreach (Device dev in _devExp.Devices)
                    devs += dev.ToString() + ";";
                return devs.Substring(0,devs.Length-1);
            }


            return "!Nem kezelet erdemény";
        }

    }
}
