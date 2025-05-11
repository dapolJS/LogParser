using System.Reflection;
using System.Text.Json;
using LogParser.Models;

namespace LogParser.Services;

public static class UserQuery
{
    public static string SearchQuery()
    {
        Console.WriteLine(
            "Provide full or partial search value, in example : signatureId=Microsoft-Windows-Security-Auditing:4608 or signatureId=4608");
        var searchQuery = Console.ReadLine()!;
        return searchQuery;
    }

    public static string SearchQueryCondition()
    {
        Console.WriteLine("======== LogParser started!");
        Console.WriteLine("Please provide condition for searching : for, not, or, and");
        var searchCondiion = Console.ReadLine()!.ToLower();
        Guard.CheckIfIsNullOrEmpty(searchCondiion);
        return searchCondiion;
    }

    public static string[] SearchQueryParsing(string searchQuery)
    {
        var searchQuerySeparated = searchQuery.Split("=",
            StringSplitOptions.TrimEntries
            | StringSplitOptions.RemoveEmptyEntries);

        if (searchQuerySeparated.Length == 2)
        {
            return searchQuerySeparated;
        }

        throw new ArgumentException("Column name or Search value was missing!");
    }

    public static List<Log> SearchLogs(List<Log> records, PropertyInfo column, string columnSearchValue,
        string searchQueryCondition)
    {
        var result = new List<Log>();

        foreach (var record in records)
        {
            var recordColumnValue = column.GetValue(record)?.ToString();

            Guard.CheckIfIsNullOrEmpty(recordColumnValue);

            if (recordColumnValue.Contains(columnSearchValue) && searchQueryCondition == "for")
            {
                result.Add(record);
            }
            else if (!recordColumnValue.Contains(columnSearchValue) && searchQueryCondition == "not")
            {
                result.Add(record);
            }
        }

        return result;
    }

    public static void OutputResult(string searchQuery, List<Log> result)
    {
        var jsonSerializerConfig = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var resultObject = new SearchResult
        {
            SearchQuery = searchQuery,
            ResultsFound = result.Count,
            Result = result
        };

        var jsonResult =
            JsonSerializer.Serialize(resultObject, jsonSerializerConfig);
        Console.WriteLine(jsonResult);
    }

    public static void ScanResultsForHighSeverityLevel(List<Log> results)
    {
        Console.WriteLine("Please provide from which severity level and above alerts should be displayed!");
        var severityLevel = Convert.ToInt32(Console.ReadLine());
        var severityCounter = 0;

        foreach (var result in results)
        {
            if (result.Severity >= severityLevel)
            {
                severityCounter++;
            }
        }

        if (severityCounter > 0)
        {
            Console.WriteLine("======== Alert! Total high severity records found : " + severityCounter);
        }
        else
        {
            Console.WriteLine($"======== No records found with severity level {severityLevel} and above");
        }
        Console.WriteLine("======== LogParser exited!");
    }
}