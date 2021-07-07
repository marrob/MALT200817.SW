namespace MALT200817.Service
{
    using System;
    using System.Text.RegularExpressions;
    using Common;
    using Library;

    public class TcpParser
    {
        readonly Explorer _exp;

        const string RESPONSE_OK = "OK";
        const string RESPONSE_NOTFOUND = "NOT FOUND";
      
        public TcpParser(Explorer explorer)
        {
            _exp = explorer;
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
                    const int FAMILY_CODE = 0;
                    const int ADDRESS = 1;
                    const int COMMAND = 2;
                    const int PARAM1 = 3;
                    const int PARAM2 = 4;

                    var parts = line.Substring(1).Split(':');

                    var familyCode = Tools.HexaByteStrToByte(parts[FAMILY_CODE]);
                    var address = Tools.HexaByteStrToByte(parts[ADDRESS]);

                    /*** 1..n-ig, 0-az hiba! ***/
                    if (parts[COMMAND] == "SET#ONE#DO")
                    {
                        _exp.SetOneOutput(familyCode, address, Tools.HexaByteStrToByte(parts[PARAM1]));
                        return RESPONSE_OK;
                    }
                    /*** 1..n-ig, 0-az hiba! ***/
                    else if (parts[COMMAND] == "CLR#ONE#DO")
                    {

                        _exp.ClrOneOutput(familyCode, address, Tools.HexaByteStrToByte(parts[PARAM1]));
                        return RESPONSE_OK;
                    }
                    /*** 1..n-ig, 0-az hiba! ***/
                    else if (parts[COMMAND] == "GET#ONE#DO")
                    {
                        var port = Tools.HexaByteStrToByte(parts[PARAM1]);
                        var retval = "@" + familyCode.ToString("X2") + ":" + address.ToString("X2") + ":STA:" + port.ToString("X2");
                        if (_exp.GetOneOutput(familyCode, address, port))
                            retval += ":SET";
                        else
                            retval += ":CLR";
                        return retval;
                    }
                    /*** 1..n-ig, 0-az hiba! ***/
                    else if (parts[COMMAND] == "GET#ONE#DI")
                    {
                        var port = Tools.HexaByteStrToByte(parts[PARAM1]);
                        var retval = "@" + familyCode.ToString("X2") + ":" + address.ToString("X2") + ":STA:" + port.ToString("X2");
                        if (_exp.GetOneInputStatus(familyCode, address, port))
                            retval += ":SET";
                        else
                            retval += ":CLR";
                        return retval;
                    }
                    //port 1-töl indexelődik
                    else if (parts[COMMAND] == "GET#COUNTER")
                    {
                        var port = Tools.HexaByteStrToByte(parts[PARAM1]);
                        if (port == 0)
                            throw new ArgumentException("Port canno be 0");
                        _exp.GetCounter(familyCode, address, port);
                        //Meg kell várni hogy a kérésre beérkezzen az üzenet a tárólóba.
                        System.Threading.Thread.Sleep(10);
                        var retval = "@" + familyCode.ToString("X2") + ":" + address.ToString("X2") + ":STA:" + port.ToString("X2") + ":";
                        retval += _exp.LiveDevices.Search(familyCode, address).Counters[port - 1].ToString("X4");
                        return retval;
                    }
                    else if (parts[COMMAND] == "SET#COUNTER")
                    {
                        var port = Tools.HexaByteStrToByte(parts[PARAM1]);
                        if (port == 0)
                            throw new ArgumentException("Port canno be 0");

                        int value = Tools.HexaByteStrToInt(parts[PARAM2]);
                        _exp.SetPortCounter(familyCode, address, port, value);
                        _exp.LiveDevices.Search(familyCode, address).Counters[port - 1] = value;
                        return RESPONSE_OK;
                    }
                    else if (parts[COMMAND] == "SAVE#COUNTER")
                    {
                        _exp.SaveCounters(familyCode, address);
                        return RESPONSE_OK;
                    }
                    else if (parts[COMMAND] == "CLR#SEVERAL#DO")
                    {
                        var block = Tools.HexaByteStrToByte(parts[PARAM2]);
                        _exp.ClrOutputs(familyCode, address, Tools.ConvertHexStringToByteArray(parts[PARAM1]), block);
                        return RESPONSE_OK;
                    }
                    else if (parts[COMMAND] == "SET#SEVERAL#DO")
                    {
                        var block = Tools.HexaByteStrToByte(parts[PARAM2]);
                        _exp.SetOutputs(familyCode, address, Tools.ConvertHexStringToByteArray(parts[PARAM1]), block);
                        return RESPONSE_OK;
                    }
                    else if (parts[COMMAND] == "GET#SEVERAL#DO")
                    {
                        var block = Tools.HexaByteStrToByte(parts[PARAM2]);
                        var state = _exp.GetOutputs(familyCode, address, block);
                        var retval = "@" + familyCode.ToString("X2") + ":" + address.ToString("X2") + ":STA:" +
                            Tools.ConvertByteArrayToString(state);
                        return retval;
                    }
                    if (parts[COMMAND] == "RESET")
                    {
                        _exp.ResetIo(familyCode, address);
                        return RESPONSE_OK;
                    }

                    else
                    {
                        var msg = "!UNKNOWN DEVICE COMMAND: '" + parts[COMMAND] + "'";
                        AppLog.Instance.WriteLine("TcpParser:Response an error, message is" + msg + "Command was:" + line);
                        return msg;
                    }
                }
                else if (line == "GET#DEVICES")
                {
                    string devs = string.Empty;
                    if (_exp.LiveDevices.Count != 0)
                    {
                        foreach (LiveDeviceItem dev in _exp.LiveDevices)
                        {

                            devs += "@" +
                                dev.FamilyCode.ToString("X2") + ":" + //FAMILY_CODE
                                dev.Address.ToString("X2") + ":" +    //ADDRESS
                                dev.OptionCode.ToString("X2") + ":" + //OPTION_CODE
                                dev.Version + ":" +                   //VERSION
                                dev.SerialNumber + ":" +              //SERIALNUMBER
                                dev.FamilyName + ":" +                //OPTION_NAME
                                dev.FirstName + //FIRST_NAME
                                ";";

                        }
                        return devs.Substring(0, devs.Length - 1);
                    }
                    else
                    {
                        return RESPONSE_NOTFOUND;
                    }
                }
                else if (line == "DO#MIANTENACNE")
                {

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
