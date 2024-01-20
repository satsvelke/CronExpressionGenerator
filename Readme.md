# Cron Expression Generator

The `CronExpression` class in the `Sats.CronExpressionGenerator` namespace provides a simple and flexible way to generate cron expressions for scheduling tasks at specified intervals and times. This generator is particularly useful for configuring cron jobs in applications.

## Usage

### DailyAt

Generates a cron expression to run a task every specified number of minutes.

```csharp
CronExpression.DailyAt(int minutes);
```

### DailyAt with StartTime

Generates a cron expression to run a task every specified number of minutes, starting from a specific time of day.

```csharp
CronExpression.DailyAt(int minutes, TimeSpan startTime);
```

### DailyAt with Time Range

Generates a cron expression to run a task every specified number of minutes within a specified time range.

```csharp
CronExpression.DailyAt(int minutes, TimeSpan startTime, TimeSpan endTime);
```

### DailyAt with Time Range and Weekdays

Generates a cron expression to run a task every specified number of minutes within a time range and on specific days of the week.

```csharp
CronExpression.DailyAt(int minutes, TimeSpan startTime, TimeSpan endTime, int[] weekDays);
```

### DailyAt with Weekdays

Generates a cron expression to run a task every specified number of minutes on specific days of the week.

```csharp
CronExpression.DailyAt(int minutes, int[] weekDays);
```

### DailyAt with Time Range and Weekdays

Generates a cron expression to run a task every specified number of minutes within a time range and on specific days of the week.

```csharp
CronExpression.DailyAt(int minutes, TimeSpan startTime, int[] weekDays);
```

### DailyOnceAt

Generates a cron expression to run a task once daily at a specific time.

```csharp
CronExpression.DailyOnceAt(TimeSpan at);
```

### DailyOnceAt with Weekdays

Generates a cron expression to run a task once daily at a specific time on specific days of the week.

```csharp
CronExpression.DailyOnceAt(TimeSpan at, int[] weekDays);
```

### OnceAt

Generates a cron expression to run a task once at a specific date and time.

```csharp
CronExpression.OnceAt(DateTime dateTime, TimeSpan at);
```

### OnceAt without Time

Generates a cron expression to run a task once at a specific date and time.

```csharp
CronExpression.OnceAt(DateTime dateTime);
```

## Weekdays Mapping

In the `CronExpression` class, weekdays are represented as integers from 0 to 6, corresponding to the following days:

- 0: Sunday
- 1: Monday
- 2: Tuesday
- 3: Wednesday
- 4: Thursday
- 5: Friday
- 6: Saturday

When specifying weekdays in the methods that involve weekdays, use the integers corresponding to the desired days.

## Example

```csharp
// Run a task every 15 minutes on Mondays and Wednesdays from 8:00 AM to 5:00 PM
var cronExpression = CronExpression.DailyAt(15, new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0), new int[] { 1, 3 });
```


