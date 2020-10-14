using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.MUDS150628
{
    public static class Log
    {
        public static Action<string> LogWriteLinePtr { get; set; }

        public static void WriteLine(string line)
        {
            LogWriteLinePtr?.Invoke(line);
        }
    }
}
