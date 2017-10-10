using System;

namespace Dll
{
    internal static class Extension
    {

        public static TimeSpan ToTimeSpan(this DateTime date)
        {
            return new TimeSpan(date.Hour, date.Minute, date.Second);
        }
    }
}
