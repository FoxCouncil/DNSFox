using DNSFox.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSFox
{
    public static class TimeUtils
    {
        public static double UnixTimestamp()
        {
            return UnixTimestamp(DateTime.Now);
        }

        public static double UnixTimestamp(DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime FromUnixTimestamp(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch                      
            return DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc).AddSeconds(unixTimeStamp);
        }

        public static string StringfyDateTimeDifference(DateTime? diff1)
        {
            if (diff1 == null)
            {
                return "0 " + Strings.MillisecondsPlural;
            }

            return StringfyDateTimeDifference(diff1.Value);
        }

        public static string StringfyDateTimeDifference(DateTime diff1)
        {
            TimeSpan diff = (DateTime.UtcNow - diff1.ToUniversalTime());

            StringBuilder sb = new StringBuilder();

            if (diff.Days != 0)
            {
                sb.AppendFormat("{0} {1} ", diff.Days, (diff.Days == 1) ? Strings.DaysSingular : Strings.DaysPlural);
                sb.AppendFormat("{0:D2} {1} ", diff.Minutes, (diff.Minutes == 1) ? Strings.MinutesSingular : Strings.MinutesPlural);
                sb.AppendFormat("{0:D2} {1}", diff.Seconds, (diff.Seconds == 1) ? Strings.SecondsSingular : Strings.SecondsPlural);
            }
            else if (diff.Minutes != 0)
            {
                sb.AppendFormat("{0} {1} ", diff.Minutes, (diff.Minutes == 1) ? Strings.MinutesSingular : Strings.MinutesPlural);
                sb.AppendFormat("{0:D2} {1}", diff.Seconds, (diff.Seconds == 1) ? Strings.SecondsSingular : Strings.SecondsPlural);
            }
            else
            {
                sb.AppendFormat("{0} {1} ", diff.Seconds, (diff.Seconds == 1) ? Strings.SecondsSingular : Strings.SecondsPlural);
                sb.AppendFormat("{0:D3} {1}", diff.Milliseconds, (diff.Milliseconds == 1) ? Strings.MillisecondsSingular : Strings.MillisecondsPlural);
            }

            return sb.ToString();
        }
    }
}
