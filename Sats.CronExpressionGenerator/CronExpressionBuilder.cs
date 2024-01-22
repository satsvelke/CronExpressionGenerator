using System;

namespace Sats.CronExpressionGenerator
{
    public sealed partial class CronExpressionBuilder
    {
        public CronExpressionBuilder()
        {
            // expression = new StringBuilder();
            // expression.Append("* * * * *");
            expression = $"|minutesPlace| |hoursPlace| |daysPlace| |monthPlace| |weekPlace|";
        }

        public string secondsPlace = "*";
        public string minutesPlace = "*";
        public string hoursPlace = "*";
        public string monthPlace = "*";
        public string daysPlace = "*";
        public string weeksPlace = "*";
        public string expression;


        public string Build()
        {
            // var chars = expression.TrimStart().TrimEnd().Split(' ');

            // var remainingLength = 6 - chars.Length;

            // for (int i = 0; i < remainingLength; i++)
            // {
            //     expression += " *";
            // }

            return expression.Replace("|secondsPlace|", secondsPlace)
            .Replace("|minutesPlace|", minutesPlace).ToString()
            .Replace("|hoursPlace|", hoursPlace).ToString()
            .Replace("|daysPlace|", daysPlace).ToString()
            .Replace("|monthPlace|", monthPlace).ToString()
            .Replace("|weekPlace|", weeksPlace).ToString();

        }

    }

}