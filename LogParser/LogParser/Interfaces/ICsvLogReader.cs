using LogParser.Models;

namespace LogParser.Interfaces;

public interface ICsvLogReader
{
    List<Log> ReadLogs(string filePath);
}