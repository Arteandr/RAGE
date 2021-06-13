using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemode.Server.Data.Utils
{
    public static class Utils
    {
        public static uint GetMsToNextHour()
        {
            var timeOfDay = DateTime.UtcNow.TimeOfDay;
            var nextFullHour = TimeSpan.FromHours(Math.Ceiling(timeOfDay.TotalHours));

            return (uint)(nextFullHour - timeOfDay).TotalMilliseconds + 1;
        }

        public static uint GetMsToNextMinute()
        {
            var timeOfDay = DateTime.UtcNow.TimeOfDay;
            var nextFullMinute = TimeSpan.FromMinutes(Math.Ceiling(timeOfDay.TotalMinutes));

            return (uint)(nextFullMinute - timeOfDay).TotalMilliseconds + 1;
        }

        public static uint GetMsToNextSecond()
        {
            var timeOfDay = DateTime.UtcNow.TimeOfDay;
            var nextFullSecond = TimeSpan.FromSeconds(Math.Ceiling(timeOfDay.TotalSeconds));

            return (uint)(nextFullSecond - timeOfDay).TotalMilliseconds + 1;
        }
    }
}
