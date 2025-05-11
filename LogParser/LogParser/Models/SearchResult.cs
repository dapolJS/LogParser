namespace LogParser.Models;

public class SearchResult
{
    public required string SearchQuery { get; set; }
    public required int ResultsFound { get; set; }
    public required List<Log> Result { get; set; }
}