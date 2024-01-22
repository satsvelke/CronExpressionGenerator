using System;

namespace Sats.CronExpressionGenerator
{
    public sealed partial class CronExpressionBuilder
    {
        public CronExpressionBuilder AtEveryHour()
        {
            hoursPlace += "1";
            return this;
        }

        public CronExpressionBuilder AtSpecificHour(int[] hour)
        {
            hoursPlace = string.Join(",", hour);
            return this;
        }

        public CronExpressionBuilder AtHourStartingFrom(int hour, int startingFrom)
        {
            hoursPlace = $"{startingFrom}/{hour}";
            return this;
        }

        public CronExpressionBuilder AtHourBetween(int start, int end)
        {
            hoursPlace = $"{start}-{end}";
            return this;
        }
    }

}

