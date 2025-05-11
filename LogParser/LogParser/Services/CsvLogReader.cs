using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using LogParser.Interfaces;
using LogParser.Models;

namespace LogParser.Services;

public class CsvLogReader : ICsvLogReader
{
    public List<Log> ReadLogs(string filePath)
    {
        var streamReader = new StreamReader(filePath);

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = headerForMatchArgs => headerForMatchArgs.Header.ToLower()
        };
        var csvReader = new CsvReader(streamReader, csvConfiguration);

        return csvReader.GetRecords<Log>().ToList();
    }
}