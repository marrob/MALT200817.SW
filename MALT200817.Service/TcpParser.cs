
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
        IDeviceExplorer _DevExp;

        public TcpParser()
        {
            _DevExp = null;
        }

        public TcpParser(IDeviceExplorer explorer)
        {
            _DevExp = explorer;
        }

        public string Parse(string line)
        {
            line = line.ToUpper();
            line = Regex.Replace(line, @"\s+", " ");

            /*
            * @CARD_TYPE, #ADDR, SET:CH
            * @05,00,SET:1
            * @05,00,CLR:1
            * 
            */

            if (line.Contains('@'))
            {
                byte cardType = 0;
                byte addr = 0;
                byte channel = 0;

                var array = line.Trim().Split(',');

                var typeStr = array[0].Trim();
                var addrStr = array[1].Trim();
                var command = array[2].Trim();

                if (!byte.TryParse(typeStr.Substring(1), out cardType))
                    return "Data Type Error of 'CARD_TYPE'";

                if (!byte.TryParse(addrStr.Substring(1), out addr))
                    return "Data Type Error of 'ADDR";

                if (command.Contains("SET"))
                {
                    if (!byte.TryParse(command.Substring("SET:".Length), out channel))
                        return "Data Type Error of 'SET'";

                    try
                    {
                        _DevExp.Set(cardType, addr, channel);
                    }
                    catch (ApplicationException ex)
                    {
                        return ex.Message;
                    }
                }
                else if (command.Contains("CLR"))
                {
                    if (!byte.TryParse(command.Substring("CLR:".Length), out channel))
                        return "Data Type Error of 'CLR'";

                    try
                    {
                        _DevExp.Clr(cardType, addr, channel);
                    }
                    catch (ApplicationException ex)
                    {
                        return ex.Message;
                    }
                }
            }

            return null;
        }

    }
}
