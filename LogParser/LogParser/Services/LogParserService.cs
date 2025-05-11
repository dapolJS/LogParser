using LogParser.Constants;
using LogParser.Interfaces;

namespace LogParser.Services;

public class LogParserService : ILogParserService
{
    private readonly ICsvLogReader _csvLogReader;
    private readonly IPropertyGetter _propertyGetter;

    public LogParserService(ICsvLogReader csvLogReader, IPropertyGetter propertyGetter)
    {
        _csvLogReader = csvLogReader;
        _propertyGetter = propertyGetter;
    }

    public void Run()
    {
        var records = _csvLogReader.ReadLogs(AppConstants.LogFilePath);

        var searchQueryCondition = UserQuery.SearchQueryCondition();
        var searchQuery = UserQuery.SearchQuery();
        var columnNameValue = UserQuery.SearchQueryParsing(searchQuery)[0];
        var columnSearchValue = UserQuery.SearchQueryParsing(searchQuery)[1];

        var column = _propertyGetter.GetPropertyData(columnNameValue);
        Guard.CheckIfColumnIsNotNull(column);

        var result = UserQuery.SearchLogs(records, column, columnSearchValue, searchQueryCondition);
        UserQuery.OutputResult(searchQuery, result);
        UserQuery.ScanResultsForHighSeverityLevel(result);
    }
}