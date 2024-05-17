//// See https://aka.ms/new-console-template for more information

//using System.Text;
//using MextFullStack.Domain;
//using MextFullStack.Domain.Entities;
//using MextFullStack.Domain.Enums;


//var filePath = "C:\\Users\\alper\\Desktop\\AccessControlLogs.txt";

// var accessControlLogsText = File.ReadAllText(filePath);

//var accessControlLogLines = accessControlLogsText.Split("\n",StringSplitOptions.RemoveEmptyEntries);

//List<AccessControlLog> accessControlLogs = new();

////var accessControlLogs = new List<AccessControlLog>();

//foreach (var logLine in accessControlLogLines)
//{
//    var accessControlLogData = logLine.Split("---", StringSplitOptions.RemoveEmptyEntries);

//    var accessControlLog = new AccessControlLog
//    {
//        Id = Guid.NewGuid(),
//        UserId = Convert.ToInt32(accessControlLogData[0]),
//        DeviceSerialNumber = accessControlLogData[1],
//        AccessType = Enum.Parse<AccessType>(accessControlLogData[2]),
//        Date = Convert.ToDateTime(accessControlLogData[3]),
//        CreatedOn = DateTime.Now
//    };

//    accessControlLogs.Add(accessControlLog);

//    //Console.WriteLine($"Reading -> Access Control Log: {logLine}");
//}

//// Filtering a List of Items

////accessControlLogs = accessControlLogs
////    .Where(log => log.AccessType == AccessType.CARD || log.AccessType == AccessType.FP)
////    .ToList();


//// Ordering a List of Items
//accessControlLogs = accessControlLogs
//    .OrderBy(log => log.UserId)
//    .ToList();


//Console.WriteLine("Lutfen bir Device Seri No bilgisi giriniz.");

//var deviceSerialNumber = Console.ReadLine();


//// Filtering a List of Items with 2 of Where Conditions
//accessControlLogs = accessControlLogs
//    .Where(log => log.DeviceSerialNumber == deviceSerialNumber && log.AccessType == AccessType.FACE)
//    .ToList();


////Console.WriteLine("Lutfen bir ID bilgisi giriniz.");

////var userId = Convert.ToInt32(Console.ReadLine());

////// Selecting a single item from a List
////var accessLog = accessControlLogs.LastOrDefault();

////if (accessLog == null)
////    Console.WriteLine("Girilen ID bilgisine ait kayit bulunamadi.");
////else
////    Console.WriteLine($"Single Access Log => UserId:{accessLog.UserId} - DeviceSerialNumber:{accessLog.DeviceSerialNumber}");


//var random = new Random();

//var stringBuilder = new StringBuilder();

//foreach (var accessControlLog in accessControlLogs)
//{
//    // Get a random number

//    var randomNumber = random.Next(0, 10000);

//    // Check whether this number is even or odd

//    accessControlLog.IsApproved = randomNumber % 2 != 0;

//    if (randomNumber % 2 == 0)
//        accessControlLog.IsApproved = false;
//    else
//        accessControlLog.IsApproved = true;

//    accessControlLog.ApprovedDate = DateTime.Now;

//    Console.WriteLine($"Writing -> Access Control Log: {accessControlLog.UserId}---{accessControlLog.DeviceSerialNumber}---{accessControlLog.AccessType}---{accessControlLog.Date}---{accessControlLog.IsApproved}---{accessControlLog.ApprovedDate}");

//    stringBuilder.AppendLine($"---{accessControlLog.UserId}---{accessControlLog.DeviceSerialNumber}---{accessControlLog.AccessType}---{accessControlLog.Date}---{accessControlLog.IsApproved}---{accessControlLog.ApprovedDate}");
//}

//var savePath = "C:\\Users\\alper\\Desktop\\CheckedAccessControlLogs.txt";

//File.AppendAllText(savePath, stringBuilder.ToString());

//Console.ReadLine();