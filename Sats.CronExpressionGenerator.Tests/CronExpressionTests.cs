using System;
using NUnit.Framework;

namespace Sats.CronExpressionGenerator.Tests
{
    [TestFixture]
    public class CronExpressionTests
    {
        [TestCase(15, ExpectedResult = "*/15 * * * *")]
        [TestCase(30, ExpectedResult = "*/30 * * * *")]
        [TestCase(60, ExpectedResult = "*/60 * * * *")]
        [TestCase(0, ExpectedResult = "* * * * *")]

        public string EveryMinuteAt_ShouldGenerateCorrectExpression(int minutes)
        {
            var k =
             CronExpression.EveryMinuteAt(minutes);

            Console.WriteLine(k);

            return k;
        }

        [TestCase(15, "08:30", ExpectedResult = "30-59/15 8-23 * * *")]
        [TestCase(30, "12:45", ExpectedResult = "45-59/30 12-23 * * *")]
        public string EveryMinuteAtWithStartTime_ShouldGenerateCorrectExpression(int minutes, string startTime)
        {
            TimeSpan startTimeSpan = TimeSpan.Parse(startTime);
            var k = CronExpression.EveryMinuteAt(minutes, startTimeSpan);

            Console.WriteLine(k);
            return k;
        }

        [TestCase(15, "08:30", "17:45", ExpectedResult = "30-45/15 8-17 * * *")]
        [TestCase(30, "12:45", "18:30", ExpectedResult = "45-30/30 12-18 * * *")]
        public string EveryMinuteAtWithTimeRange_ShouldGenerateCorrectExpression(int minutes, string startTime, string endTime)
        {
            TimeSpan startTimeSpan = TimeSpan.Parse(startTime);
            TimeSpan endTimeSpan = TimeSpan.Parse(endTime);
            return CronExpression.EveryMinuteAt(minutes, startTimeSpan, endTimeSpan);
        }

        [TestCase(15, "08:30", "17:45", new[] { 1, 3, 5 }, ExpectedResult = "30-45/15 8-17 * * 1-5")]
        [TestCase(30, "12:45", "18:30", new[] { 2, 4 }, ExpectedResult = "45-30/30 12-18 * * 2-4")]
        public string EveryMinuteAtWithTimeRangeAndWeekDays_ShouldGenerateCorrectExpression(int minutes, string startTime, string endTime, int[] weekDays)
        {
            TimeSpan startTimeSpan = TimeSpan.Parse(startTime);
            TimeSpan endTimeSpan = TimeSpan.Parse(endTime);
            return CronExpression.EveryMinuteAt(minutes, startTimeSpan, endTimeSpan, weekDays);
        }

        [TestCase(15, new[] { 1, 3, 5 }, ExpectedResult = "*/15 * * * 1-5")]
        [TestCase(30, new[] { 2, 4 }, ExpectedResult = "*/30 * * * 2-4")]
        public string EveryMinuteAtWithWeekDays_ShouldGenerateCorrectExpression(int minutes, int[] weekDays)
        {
            return CronExpression.EveryMinuteAt(minutes, weekDays);
        }

        [TestCase("08:30", ExpectedResult = "30 8 * * *")]
        [TestCase("12:45", ExpectedResult = "45 12 * * *")]
        public string DailyOnceAt_ShouldGenerateCorrectExpression(string at)
        {
            TimeSpan atTimeSpan = TimeSpan.Parse(at);
            return CronExpression.DailyOnceAt(atTimeSpan);
        }

        [TestCase("08:30", new[] { 1, 3, 5 }, ExpectedResult = "30 8 * * 1-5")]
        [TestCase("12:45", new[] { 2, 4 }, ExpectedResult = "45 12 * * 2-4")]
        public string DailyOnceAtWithWeekDays_ShouldGenerateCorrectExpression(string at, int[] weekDays)
        {
            TimeSpan atTimeSpan = TimeSpan.Parse(at);
            return CronExpression.DailyOnceAt(atTimeSpan, weekDays);
        }

        [TestCase("2024-01-20", "08:30", ExpectedResult = "30 8 20 1 *")]
        [TestCase("2023-12-15", "12:45", ExpectedResult = "45 12 15 12 *")]
        public string OnceAt_ShouldGenerateCorrectExpression(string dateTime, string at)
        {
            DateTime specificDateTime = DateTime.Parse(dateTime);
            TimeSpan atTimeSpan = TimeSpan.Parse(at);
            return CronExpression.OnceAt(specificDateTime, atTimeSpan);
        }

        [TestCase("2024-01-20T08:30:00", ExpectedResult = "30 8 20 1 *")]
        [TestCase("2023-12-15T12:45:00", ExpectedResult = "45 12 15 12 *")]
        public string OnceAtWithDateTime_ShouldGenerateCorrectExpression(string dateTime)
        {
            DateTime specificDateTime = DateTime.Parse(dateTime);
            return CronExpression.OnceAt(specificDateTime);
        }


        [TestCase(5, "10:15", "18:30", new[] { 2, 4, 6 }, ExpectedResult = "15-30/5 10-18 * * 2-6")]
        [TestCase(60, "12:00", "15:00", new[] { 1, 7 }, ExpectedResult = "0-0/60 12-15 * * 1-7")]

        public string EveryMinuteAtWithTimeRangeAndWeekDays_AdditionalCases(int minutes, string startTime, string endTime, int[] weekDays)
        {
            TimeSpan startTimeSpan = TimeSpan.Parse(startTime);
            TimeSpan endTimeSpan = TimeSpan.Parse(endTime);
            return CronExpression.EveryMinuteAt(minutes, startTimeSpan, endTimeSpan, weekDays);
        }

        [TestCase("09:15", new[] { 1, 2, 4 }, ExpectedResult = "15 9 * * 1-4")]
        [TestCase("14:30", new[] { 3, 5 }, ExpectedResult = "30 14 * * 3-5")]
        [TestCase("18:45", new[] { 6, 7 }, ExpectedResult = "45 18 * * 6-7")]
        public string DailyOnceAtWithWeekDays_AdditionalCases(string at, int[] weekDays)
        {
            TimeSpan atTimeSpan = TimeSpan.Parse(at);
            return CronExpression.DailyOnceAt(atTimeSpan, weekDays);
        }

        [TestCase("2024-02-10", "03:30", ExpectedResult = "30 3 10 2 *")]
        [TestCase("2023-11-05", "06:15", ExpectedResult = "15 6 5 11 *")]
        public string OnceAtWithDateTime_AdditionalCases(string dateTime, string at)
        {
            DateTime specificDateTime = DateTime.Parse(dateTime);
            TimeSpan atTimeSpan = TimeSpan.Parse(at);
            return CronExpression.OnceAt(specificDateTime, atTimeSpan);
        }


        [Test]
        public void EveryMinuteAt_InvalidMinutes_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => CronExpression.EveryMinuteAt(75));
        }

        [TestCase(75, new[] { 1, 3, 5 })]
        [TestCase(90, new[] { 2, 4 })]
        [TestCase(120, new[] { 6, 7 })]
        public void EveryMinuteAtWithWeekDays_InvalidMinutes_ShouldThrowArgumentException(int minutes, int[] weekDays)
        {
            Assert.Throws<ArgumentException>(() => CronExpression.EveryMinuteAt(minutes, weekDays));
        }


    }
}

