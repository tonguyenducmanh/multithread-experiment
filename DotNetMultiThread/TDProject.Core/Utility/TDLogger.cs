using System.Runtime.CompilerServices;

namespace TDProject.Core.Utility;

/// <summary>
/// Class log util
/// </summary>
public static class TDLogger
{
    /// <summary>
    /// Log thời gian chạy
    /// </summary>
    /// <param name="message">nội dung log</param>
    public static string LogRuntime(string message)
    {
        DateTime timeRun = DateTime.Now;
        string logFunctionInfo = $"{timeRun}: {message}";
        Console.WriteLine(logFunctionInfo);
        return logFunctionInfo;
    }
}