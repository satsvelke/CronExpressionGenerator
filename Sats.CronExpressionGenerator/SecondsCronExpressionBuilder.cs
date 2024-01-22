namespace Sats.CronExpressionGenerator
{
    public sealed partial class CronExpressionBuilder
    {
        public CronExpressionBuilder AtSecondStartingFrom(int second, int startingFrom)
        {
            secondsPlace = $"{startingFrom}/{second}";
            return this;
        }

        public CronExpressionBuilder AtSpecificSecond(int[] seconds)
        {
            secondsPlace = string.Join(",", seconds);
            return this;
        }

        public CronExpressionBuilder AtSecondBetween(int start, int end)
        {
            secondsPlace = $"{start}-{end}";
            return this;
        }
    }

}

