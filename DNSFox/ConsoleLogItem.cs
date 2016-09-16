using DNSFox.Enums;
using DNSFox.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSFox
{
    /// <summary>
    /// A class representing one log line item
    /// </summary>
    public class ConsoleLogItem
    {
        /// <summary>
        /// The timestamp that this log line was recorded at
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The type of console message
        /// </summary>
        public ConsoleLogType Type { get; set; }

        /// <summary>
        /// The console log message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Override for ToString to support display in a ListBox control
        /// </summary>
        /// <returns>Internationalized string format output of Timestamp, Type and Message</returns>
        public override string ToString()
        {
            return string.Format(Strings.ConsoleLogFormat, Timestamp, Type, Message);
        }
    }
}
