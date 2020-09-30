namespace MALT200817.Service
{
    using System;
    using System.Text.RegularExpressions;
    using Common;
    using Library;

    public class TcpParser
    {
        readonly Explorer _devExp;

        const string RESPONSE_OK = "OK";
        const string RESPONSE_NOTFOUND = "NOT FOUND";
      
        public TcpParser(Explorer explorer)
        {
            _devExp = explorer;
        }

        public string CommandLine(string line)
        {
            line = line.ToUpper();
            line = Regex.Replace(line, @"\s+", " ");
            try
            {
                if (line == "*OPC?")
                {
                    return "OPC";
                }
                else if (line[0] == '@')
                {
                    const int PART_FAMILY_CODE = 0;
                    const int PART_ADDRES = 1;
                    const int PART_COMMAND = 2;
                    const int PART_PARAM1 = 3;
                    const int PART_PARAM2 = 4;

                    var parts = line.Substring(1).Split(':');

                    var familyCode = Tools.HexaByteStrToByte(parts[PART_FAMILY_CODE]);
                    var address = Tools.HexaByteStrToByte(parts[PART_ADDRES]);

                    /*** 1..n-ig, 0-az hiba! ***/
                    if (parts[PART_COMMAND] == "SET#ONE")
                    {
                        _devExp.RequestSetOne(familyCode, address, Tools.HexaByteStrToByte(parts[PART_PARAM1]));
                        return RESPONSE_OK;
                    }
                    /*** 1..n-ig, 0-az hiba! ***/
                    else if (parts[PART_COMMAND] == "CLR#ONE")
                    {

                        _devExp.RequestClrOne(familyCode, address, Tools.HexaByteStrToByte(parts[PART_PARAM1]));
                        return RESPONSE_OK;
                    }
                    /*** 1..n-ig, 0-az hiba! ***/
                    else if (parts[PART_COMMAND] == "GET#ONE")
                    {
                        var port = Tools.HexaByteStrToByte(parts[PART_PARAM1]);
                        var retval = "@" + familyCode.ToString("X2") + ":" + address.ToString("X2") + ":STA:" + port.ToString("X2");
                        if (_devExp.GetOne(familyCode, address, port))
                            retval += ":SET";
                        else
                            retval += ":CLR";
                        return retval;
                    }
                    ///Todo:Download Counter lesz
                    else if (parts[PART_COMMAND] == "UPDATE#COUNTER")
                    {
                        var port = Tools.HexaByteStrToByte(parts[PART_PARAM1]);
                        _devExp.RequestPortCounter(familyCode, address, port);
                        return RESPONSE_OK;
                    }
                    //port 1-töl indexelődik
                    else if (parts[PART_COMMAND] == "GET#COUNTER")
                    {
                        var port = Tools.HexaByteStrToByte(parts[PART_PARAM1]);
                        if (port == 0)
                            throw new ArgumentException("Port canno be 0");
                        var retval = "@" + familyCode.ToString("X2") + ":" + address.ToString("X2") + ":STA:" + port.ToString("X2") + ":";
                        retval += _devExp.LiveDevices.Search(familyCode, address).Counters[port-1].ToString("X4");
                        return retval;
                    }
                    else if (parts[PART_COMMAND] == "CLR#SEVERAL")
                    { 
                        var block = Tools.HexaByteStrToByte(parts[PART_PARAM2]);
                        _devExp.RequestClrSeveral(familyCode, address, Tools.ConvertHexStringToByteArray(parts[PART_PARAM1]), block);
                        return RESPONSE_OK;
                    }
                    else if (parts[PART_COMMAND] == "SET#SEVERAL")
                    {
                        var block = Tools.HexaByteStrToByte(parts[PART_PARAM2]);
                        _devExp.RequestSetSeveral(familyCode, address, Tools.ConvertHexStringToByteArray(parts[PART_PARAM1]), block);
                        return RESPONSE_OK;
                    }
                    else if (parts[PART_COMMAND] == "GET#SEVERAL")
                    {
                        var block = Tools.HexaByteStrToByte(parts[PART_PARAM2]);
                        var state = _devExp.GetSeveral(familyCode, address, block);
                        var retval = "@" + familyCode.ToString("X2") + ":" + address.ToString("X2") + ":STA:" +
                            Tools.ConvertByteArrayToString(state);
                        return retval;
                    }
                    if (parts[PART_COMMAND] == "RESET")
                    {
                        _devExp.RequestReset(familyCode, address);
                        return RESPONSE_OK;
                    }

                    else
                    {
                        var msg = "!UNKNOWN DEVICE COMMAND: '" + parts[PART_COMMAND] + "'";
                        AppLog.Instance.WriteLine("TcpParser:Response an error, message is" + msg + "Command was:" + line);
                        return msg;
                    }
                }
                else if (line == "GET#DEVICES")
                {
                    string devs = string.Empty;
                    if (_devExp.LiveDevices.Count != 0)
                    {
                        foreach (LiveDeviceItem dev in _devExp.LiveDevices)
                        {
                            var firstName = Devices.Library.Search(dev.FamilyCode, dev.OptionCode).FirstName;
                            devs += "@" +
                                dev.FamilyCode.ToString("X2") + ":" + //FAMILY_CODE
                                dev.Address.ToString("X2") + ":" +    //ADDRESS
                                dev.OptionCode.ToString("X2") + ":" + //OPTION_CODE
                                dev.Version + ":" +                   //VERSION
                                dev.SerialNumber + ":" +              //SERIALNUMBER
                                dev.Device.FamilyName + ":" +         //FAMILY_NAME
                                (firstName ?? "UNKNOWN FIRST NAME") + //FIRST_NAME
                                ";";
                        }
                        return devs.Substring(0, devs.Length - 1);
                    }
                    else
                    {
                        return RESPONSE_NOTFOUND;
                    }

                }
                else if (line == "UPDATE#DEVICES:INFO")
                {
                    _devExp.DoUpdateDeviceInfo();
                    return RESPONSE_OK;
                }
                else if (line == "DO#SAY:HELLO WOLRD")
                {
                    return "HELLO WORLD";
                }
                else
                {
                    var msg = "!UNKNOWN DEVICE COMMAND: '" + line + "'";
                    AppLog.Instance.WriteLine("TcpParser:Response an error, message is" + msg + "Command was:" + line);
                    return msg;
                }
            }
            catch (Exception ex)
            {
                AppLog.Instance.WriteLine("TcpParser:Response an error, message is" + ex.Message + "Command was:" + line);
                return "!" + ex.Message;

            }
        }

    }
}
