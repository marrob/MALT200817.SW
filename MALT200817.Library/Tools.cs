

namespace MALT200817.Library
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    static class Tools
    {
        public static int HexaByteStrToInt(string value)
        {
            return int.Parse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        public static byte HexaByteStrToByte(string value)
        {
            return byte.Parse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }
    }

}
