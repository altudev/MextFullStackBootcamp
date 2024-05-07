// See https://aka.ms/new-console-template for more information

using MextFullStack.Domain;
using MextFullStack.Domain.Entities;
using MextFullStack.Domain.Enums;


var filePath = "C:\\Users\\alper\\Desktop\\AccessControlLogs.txt";

 var accessControlLogsText = File.ReadAllText(filePath);

var accessControlLogLines = accessControlLogsText.Split("\n",StringSplitOptions.RemoveEmptyEntries);

List<AccessControlLog> accessControlLogs = new();

//var accessControlLogs = new List<AccessControlLog>();

foreach (var logLine in accessControlLogLines)
{
    var accessControlLogData = logLine.Split("---", StringSplitOptions.RemoveEmptyEntries);

    var accessControlLog = new AccessControlLog
    {
        Id = Guid.NewGuid(),
        UserId = Convert.ToInt32(accessControlLogData[0]),
        DeviceSerialNumber = accessControlLogData[1],
        AccessType = Enum.Parse<AccessType>(accessControlLogData[2]),
        Date = Convert.ToDateTime(accessControlLogData[3]),
        CreatedOn = DateTime.Now
    };

    accessControlLogs.Add(accessControlLog);
}