namespace MALT200817.Service
{
    using System;
    using System.Text.RegularExpressions;
    using Devices;
    using System.Globalization;
    using Common;

    public class TcpParser
    {
        readonly IExplorer _devExp;

        const string RESPONSE_OK = "OK";
        const string RESPONSE_NOTFOUND = "NOT FOUND";
      
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
                    else
                    {
                        return "!UNKNOWN DEVICE COMMAND: '" + parts[PART_COMMAND] + "'";
                    }
                }
                else if (line == "GET#DEVICES")
                {
                    string devs = string.Empty;
                    if (_devExp.LiveDevices.Count != 0)
                    {
                        foreach (LiveDeviceItem dev in _devExp.LiveDevices)
                        {
                            devs += "@" +
                                dev.FamilyCode.ToString("X2") + ":" + //FAMILY_CODE
                                dev.Address.ToString("X2") + ":" +    //ADDRESS
                                dev.OptionCode.ToString("X2") + ":" + //OPTION_CODE
                                dev.Version + ":" +                   //VERSION
                                dev.SerialNumber + ":" +              //SERIALNUMBER
                                dev.Descriptor.FamilyName + ":" +     //FAMILY_NAME
                                "Todo FIRST_NAME" +
                                ";";
                        }
                        return devs.Substring(0, devs.Length - 1);
                    }
                    else
                    {
                        return RESPONSE_NOTFOUND;
                    }

                }
                else if (line == "DO#UPDATE:DEVICES:INFO")
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
                    return "!UNKNOWN DEVICE COMMAND: '" + line + "'";
                }
            }
            catch (Exception ex)
            {
                return "!" + ex.Message;
            }



            //return "!Nem kezelet erdemény";
        }

    }
}
