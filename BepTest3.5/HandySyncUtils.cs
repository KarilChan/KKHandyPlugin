using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KKHandy
{
    class HandySyncUtils
    {
        public static long GetTimestamp()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
