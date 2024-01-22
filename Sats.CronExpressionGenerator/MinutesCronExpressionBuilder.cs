using System;

namespace Sats.CronExpressionGenerator
{
    public sealed partial class CronExpressionBuilder
    {
        public CronExpressionBuilder AtEveryMinute()
        {
            minutesPlace += "1";
            return this;
        }

        public CronExpressionBuilder AtSpecificMinute(int[] minutes)
        {
            minutesPlace = string.Join(",", minutes);
            return this;
        }

        public CronExpressionBuilder AtMinuteStartingFrom(int minutes, int startingFrom)
        {
            minutesPlace = $"{startingFrom}/{minutes}";
            return this;
        }

        public CronExpressionBuilder AtMinuteBetween(int start, int end)
        {
            minutesPlace = $"{start}-{end}";
            return this;
        }
    }
}


