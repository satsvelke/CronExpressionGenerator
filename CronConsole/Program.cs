using Sats.CronExpressionGenerator;



var a = new CronExpressionBuilder().AtSpecificMinute(new[] { 5 }).Build();

var b = new CronExpressionBuilder().AtSpecificMinute(new[] { 5 }).Build();

var c = new CronExpressionBuilder().AtMinuteStartingFrom(3, 6).AtMinuteBetween(2, 3).Build();

var d = new CronExpressionBuilder().AtMinuteStartingFrom(5, 20).AtHourStartingFrom(10, ).Build();




Console.WriteLine(a);

Console.WriteLine(b);

Console.WriteLine(c);

Console.WriteLine(d);

