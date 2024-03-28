# Token Schedule

A simple C# library for managing token distribution schedules.

## Features

- Define token distribution schedules with start and end times and ratios.
- Validate schedules to ensure correct distribution.
- Retrieve the Token Generation Event (TGE) and subsequent distribution events.

## Usage

### Creating a Schedule and Retrieving Information

```csharp
using TokenSchedule;

// Define schedule data
var scheduleData = new List<SingleRow>
{
    new SingleRow(0.2m, new DateTime(2024, 1, 1)),
    new SingleRow(0.3m, new DateTime(2024, 2, 1), new DateTime(2024, 3, 1)),
    new SingleRow(0.5m, new DateTime(2024, 4, 1), new DateTime(2024, 5, 1))
};

// Create a new schedule
var schedule = new ScheduleInfo(scheduleData);

// Retrieve TGE information
var tge = schedule.GetTge();
Console.WriteLine($"TGE Ratio: {tge.Ratio}, Start Time: {tge.StartTime}");

// Retrieve the rest of the schedule information
var restOfSchedule = schedule.GetRest();
foreach (var row in restOfSchedule)
{
    Console.WriteLine($"Ratio: {row.Ratio}, Start Time: {row.StartTime}, End Time: {row.EndTime}");
}
```

### Requirements

.NET 6.0 or later

### License
This project is licensed under the MIT License - see the LICENSE file for details.
