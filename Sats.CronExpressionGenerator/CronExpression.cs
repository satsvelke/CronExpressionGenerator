using System;
using System.Globalization;
using System.Linq;

namespace Sats.CronExpressionGenerator
{
    public static partial class CronExpression
    {

        /// <summary>
        /// Generates a cron expression to run a task every specified number of minutes.
        /// </summary>
        /// <param name="minutes">The interval in minutes.</param>
        /// <returns>A cron expression for the specified interval.</returns>
        public static string EveryMinuteAt(int minutes)
        {
            ValidateMinutes(minutes);
            var expression = minutes == 0 ? "*" : $"*/{minutes}";
            return $"{expression} * * * *";
        }





        /// <summary>
        /// Generates a cron expression to run a task every specified number of minutes, starting from a specific time of day.
        /// </summary>
        /// <param name="minutes">The interval in minutes.</param>
        /// <param name="startTime">The starting time of day.</param>
        /// <returns>A cron expression for the specified interval and start time.</returns>
        public static string EveryMinuteAt(int minutes, TimeSpan startTime)
        {
            ValidateMinutes(minutes);
            return $"{startTime.Minutes}-59/{minutes} {startTime.Hours}-23 * * *";
        }


        /// <summary>
        /// Generates a cron expression to run a task every specified number of minutes within a specified time range.
        /// </summary>
        /// <param name="minutes">The interval in minutes.</param>
        /// <param name="startTime">The starting time of day.</param>
        /// <param name="endTime">The ending time of day.</param>
        /// <returns>A cron expression for the specified interval and time range.</returns>
        public static string EveryMinuteAt(int minutes, TimeSpan startTime, TimeSpan endTime)
        {
            ValidateMinutes(minutes);

            return $"{startTime.Minutes}-{endTime.Minutes}/{minutes} {startTime.Hours}-{endTime.Hours} * * *";
        }






        /// <summary>
        /// Generates a cron expression to run a task every specified number of minutes within a time range and on specific days of the week.
        /// </summary>
        /// <param name="minutes">The interval in minutes.</param>
        /// <param name="startTime">The starting time of day.</param>
        /// <param name="endTime">The ending time of day.</param>
        /// <param name="weekDays">An array of integers representing days of the week (1-7).</param>
        /// <returns>A cron expression for the specified interval, time range, and days of the week.</returns>
        public static string EveryMinuteAt(int minutes, TimeSpan startTime, TimeSpan endTime, int[] weekDays)
        {
            ValidateMinutes(minutes);

            return $"{startTime.Minutes}-{endTime.Minutes}/{minutes} {startTime.Hours}-{endTime.Hours} * * {GetWeekDayExpression(weekDays)}";
        }





        /// <summary>
        /// Generates a cron expression to run a task every specified number of minutes on specific days of the week.
        /// </summary>
        /// <param name="minutes">The interval in minutes.</param>
        /// <param name="weekDays">An array of integers representing days of the week (1-7).</param>
        /// <returns>A cron expression for the specified interval and days of the week.</returns>
        public static string EveryMinuteAt(int minutes, int[] weekDays)
        {
            ValidateMinutes(minutes);

            return $"*/{minutes} * * * {GetWeekDayExpression(weekDays)}";
        }






        /// <summary>
        /// Generates a cron expression to run a task every specified number of minutes within a time range and on specific days of the week.
        /// </summary>
        /// <param name="minutes">The interval in minutes.</param>
        /// <param name="startTime">The starting time of day.</param>
        /// <param name="weekDays">An array of integers representing days of the week (1-7).</param>
        /// <returns>A cron expression for the specified interval, time range, and days of the week.</returns>
        public static string EveryMinuteAt(int minutes, TimeSpan startTime, int[] weekDays)
        {
            ValidateMinutes(minutes);

            return $"{startTime.Minutes}-59/{minutes} {startTime.Hours}-23 * * {GetWeekDayExpression(weekDays)}";
        }




        /// <summary>
        /// Generates a cron expression to run a task once daily at a specific time.
        /// </summary>
        /// <param name="at">The time of day to run the task.</param>
        /// <returns>A cron expression for running the task daily at the specified time.</returns>
        public static string DailyOnceAt(TimeSpan at) => $"{at.Minutes} {at.Hours} * * *";




        /// <summary>
        /// Generates a cron expression to run a task once daily at a specific time on specific days of the week.
        /// </summary>
        /// <param name="at">The time of day to run the task.</param>
        /// <param name="weekDays">An array of integers representing days of the week (1-7).</param>
        /// <returns>A cron expression for running the task daily at the specified time on specified days of the week.</returns>
        public static string DailyOnceAt(TimeSpan at, int[] weekDays) => $"{at.Minutes} {at.Hours} * * {GetWeekDayExpression(weekDays)}";




        /// <summary>
        /// Generates a cron expression to run a task once at a specific date and time.
        /// </summary>
        /// <param name="dateTime">The specific date and time to run the task.</param>
        /// <param name="at">The time of day to run the task.</param>
        /// <returns>A cron expression for running the task once at the specified date and time.</returns>
        public static string OnceAt(DateTime dateTime, TimeSpan at) => $"{at.Minutes} {at.Hours} {dateTime.Day} {dateTime.Month} *";


        /// <summary>
        /// Generates a cron expression to run a task once at a specific date and time.
        /// </summary>
        /// <param name="dateTime">The specific date and time to run the task.</param>
        /// <returns>A cron expression for running the task once at the specified date and time.</returns>
        public static string OnceAt(DateTime dateTime) => $"{dateTime.Minute} {dateTime.Hour} {dateTime.Day} {dateTime.Month} *";

        private static string GetWeekDayExpression(int[] weekDays)
        {
            var startDay = weekDays.FirstOrDefault();

            var weekDayExpression = string.Empty;

            if (weekDays.Length > 1)
            {
                var endDay = weekDays.Reverse().FirstOrDefault();
                weekDayExpression = $"{startDay}-{endDay}";
            }
            else weekDayExpression = startDay.ToString(CultureInfo.InvariantCulture);

            return weekDayExpression;
        }

        private static Action<int> ValidateMinutes = minutes =>
        {
            if (minutes > 60) throw new ArgumentException("minutes should not be greater than 60");
        };

        private static void ValidateTimeRange(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime > endTime)
            {
                throw new ArgumentException("startTime should be less than or equal to endTime");
            }
        }

        private static void ValidateWeekDays(int[] weekDays)
        {
            if (weekDays == null || weekDays.Length == 0 || weekDays.Any(day => day < 1 || day > 7))
            {
                throw new ArgumentException("Invalid weekDays array");
            }
        }
    }
}