using System;
using System.IO;

public class Logger : IDisposable
{
    /// <summary>
    /// Gets the open parameter that tells whether the log file is open.
    /// </summary>
    public bool IsOpen { get { return _open; } }

    protected int _logLevel;
    protected string _logFilePath;
    protected bool _open;
    protected FileMode _mode;
    protected Stream _logStream;
    protected StreamWriter _logWriter;

    /// <summary>
    /// Creates a LOGGER.
    /// </summary>
    /// <param name="logFilePath">The path to the file that the logger should write to.</param>
    /// <param name="logLevel">
    /// The level of the message that is to be written to the log.
    /// Log Levels are definied as follows:
    /// 0 => FATAL,
    /// 1 => ERROR,
    /// 2 => WARN,
    /// 3 => INFO,
    /// 4 => VERBOSE
    /// </param>
    public Logger(string logFilePath, int logLevel, FileMode mode)
    {
        _logFilePath = logFilePath;
        _logLevel = logLevel;
        _mode = mode;
        Open();
    }

    /// <summary>
    /// Opens the file that the logger will write.
    /// </summary>
    public void Open()
    {
        try
        {
            _logStream = new FileStream(_logFilePath, _mode, FileAccess.Write);
            _logWriter = new StreamWriter(_logStream);
            _open = true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR : Failed to open '{_logFilePath}'");
            Console.WriteLine($"ERROR : {e.Message}");
        }
    }

    /// <summary>
    /// Disposes of the logger's streams and writers.
    /// </summary>
    public void Dispose()
    {
        _logWriter.Dispose();
        _logStream.Dispose();
    }

    /// <summary>
    /// Writes the message to the log file if open.
    /// </summary>
    /// <param name="logLevel">The log level for this message.</param>
    /// <param name="message">The message to be written to the log file.</param>
    public void WriteLog(int logLevel, string message)
    {
        if (_open && logLevel <= _logLevel)
        {
            var logMessage = $"{LogManager.ParseLogLevel(logLevel)} : {message}";
            _logWriter.WriteLine(logMessage);
        }
        else if(!_open)
        {
            Console.WriteLine($"ERROR : Failed to write log. Log file '{_logFilePath}' not open!");
        }
    }
}