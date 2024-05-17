using System.Net.Http.Json;
using MextFullStack.ConsoleClient;
using MextFullStack.Domain.Common;
using MextFullStack.Domain.Entities;

var apiUrl = "http://localhost:5106/api/";

var client = new HttpClient()
{
    BaseAddress = new Uri(apiUrl)
};
// http://localhost:5106/api/Products

var products = await client.GetFromJsonAsync<List<Product>>("Products");


foreach (var product in products)
{
    Console.WriteLine($"Product: {product.Name} - {product.Price}");
}

Console.ReadKey();

ConsoleLogger consoleLogger = new ConsoleLogger("TungaConsoleLogger","#FFFFFF",LogType.Warning);

FileLogger fileLogger = new FileLogger("TungaFileLogger");

fileLogger.Log("asdasdasd",LogType.Information);