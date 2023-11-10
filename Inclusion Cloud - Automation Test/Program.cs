using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

class Program
{
    static void Main()
    {
        #region Question 3
        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
        #endregion

        #region Question 4
        List<Dictionary<string, int>> listOfDictionaries = new()
        {
            new Dictionary<string, int> { { "x", 3 }, { "y", 10 } },
            new Dictionary<string, int> { { "x", 5 }, { "y", 15 } },
            new Dictionary<string, int> { { "x", 8 }, { "y", 20 } }
        };

        var result = listOfDictionaries.FirstOrDefault(d => d.ContainsKey("x") && d["x"] == 5) ?? new Dictionary<string, int>();

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
        #endregion

        #region Question 5
        string filePath = "/Users/acaciomelo/Downloads/automation_test.json";
        string json = File.ReadAllText(filePath);
        JObject jsonObj = JObject.Parse(json);

        // Find and print the Payee ID value
        int payeeId = jsonObj["payee"]["id"].Value<int>();
        Console.WriteLine($"Payee ID: {payeeId}");

        // Any invoices that contain the text “583”
        var invoicesContaining583 = jsonObj["invoiceIds"]
            .Where(invoice => invoice.ToString().Contains("583"))
            .Select(invoice => invoice.ToString());
        Console.WriteLine("Invoices containing '583':");
        foreach (var invoice in invoicesContaining583)
        {
            Console.WriteLine(invoice);
        }

        // Change date/time fields to text in the specified format
        DateTime claimDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)jsonObj["claimDateTime"]).DateTime;
        DateTime fileDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)jsonObj["fileDateTime"]).DateTime;
        DateTime receivedDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)jsonObj["receivedDateTime"]).DateTime;
        jsonObj["claimDateTime"] = claimDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
        jsonObj["fileDateTime"] = fileDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
        jsonObj["receivedDateTime"] = receivedDateTime.ToString("yyyy-MM-ddTHH:mm:ss");

        // Write the json document back out to a new file
        string newFilePath = "/Users/acaciomelo/Downloads/result.json";
        File.WriteAllText(newFilePath, jsonObj.ToString(Formatting.Indented));
        Console.WriteLine($"Updated JSON written to: {newFilePath}");
        #endregion
    }
}






