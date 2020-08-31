using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.ServiceTests.Common
{
    public class Tools
    {
        /// <summary>
        /// ByteArray To C-Style String.
        /// </summary>
        /// <param name="data">byte[] data</param>
        /// <returns>0x00,0x01</returns>
        public static string ConvertByteArrayToCStyleString(byte[] data)
        {
            string retval = string.Empty;
            for (int i = 0; i < data.Length; i++)
                retval += string.Format("0x{0:X2},", data[i]);
            //Az utolsó vessző törlése
            if (data.Length > 1)
                retval = retval.Remove(retval.Length - 1, 1);
            return retval;
        }
    }
}
