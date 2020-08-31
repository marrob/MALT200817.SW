
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
    using System.Runtime.InteropServices;

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
            try
            {
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
                    const int PART_CARD_TYPE = 0;
                    const int PART_ADDRES = 1;
                    const int PART_COMMAND = 2;
                    const int PART_PARAM1 = 3;
                    const int PART_PARAM2 = 4;

                    byte cardType;
                    byte addr;
                    var parts = line.Substring(1).Split(':');

                    if (!byte.TryParse(parts[PART_CARD_TYPE], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out cardType))
                        return "!Data Type Error of 'CARD_TYPE'";

                    if (!byte.TryParse(parts[PART_ADDRES], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out addr))
                        return "!Data Type Error of 'ADDR";

                    if (parts[PART_COMMAND] == "SET#ONE")
                    {
                        _devExp.RequestSetOne(cardType, addr,
                            byte.Parse(parts[PART_PARAM1], NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                        return "OK";
                    }
                    else if (parts[PART_COMMAND] == "CLR#ONE")
                    {
                        _devExp.RequestClrOne(cardType, addr,
                            byte.Parse(parts[PART_PARAM1], NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                        return "OK";
                    }
                    else if (parts[PART_COMMAND] == "GET#ONE")
                    {
                        byte port;
                        if (!byte.TryParse(parts[PART_PARAM1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out port))
                            return "!Data Type Error of " + parts[PART_COMMAND];
                        var retval = "@" + cardType.ToString("X2") + ":" + addr.ToString("X2") + ":STA:" + port.ToString("X2");
                        if (_devExp.GetOne(cardType, addr, (byte)(port - 1)))
                            retval += ":SET";
                        else
                            retval += ":CLR";
                        return retval;
                    }
                    else if (parts[PART_COMMAND] == "CLR#SEVERAL")
                    {
                        byte block = Explorer.FIRST_BLOCK;
                        if (!byte.TryParse(parts[PART_PARAM2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out block))
                            return "!Data Type Error of " + parts[PART_COMMAND];

                        _devExp.RequestClrSeveral(cardType, addr, Tools.ConvertHexStringToByteArray(parts[PART_PARAM1]), Explorer.FIRST_BLOCK);
                        return "OK";
                    }
                    else if (parts[PART_COMMAND] == "SET#SEVERAL")
                    {
                        byte block = Explorer.FIRST_BLOCK;
                        if (!byte.TryParse(parts[PART_PARAM2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out block))
                            return "!Data Type Error of " + parts[PART_COMMAND];

                        _devExp.RequestSetSeveral(cardType, addr, Tools.ConvertHexStringToByteArray(parts[PART_PARAM1]), Explorer.FIRST_BLOCK);
                        return "OK";
                    }
                    else if (parts[PART_COMMAND] == "GET#SEVERAL")
                    {
                        byte block = Explorer.FIRST_BLOCK;
                        if (!byte.TryParse(parts[PART_PARAM2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out block))
                            return "!Data Type Error of " + parts[PART_COMMAND];

                        var state = _devExp.GetSeveral(cardType, addr, Explorer.FIRST_BLOCK);
                        var retval = "@" + cardType.ToString("X2") + ":" + addr.ToString("X2") + ":STA:" +
                            Tools.ConvertByteArrayToString(state);
                        return retval;
                    }
                    else
                    {
                        return "!UNKNOWN DEVICE COMMAND: '" + parts[PART_COMMAND] + "'";
                    }
                }

                if (line == "GET#DEVICES")
                {
                    string devs = string.Empty;
                    foreach (Device dev in _devExp.Devices)
                        devs += dev.ToString() + ";";
                    return devs.Substring(0, devs.Length - 1);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }



            return "!Nem kezelet erdemény";
        }

    }
}
