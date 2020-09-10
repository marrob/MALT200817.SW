namespace MALT200817.Explorer.Common
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;
    using System.Globalization;

    public static class Tools
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
