using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Manages all loggers for writing information to both the console and log files.
/// Log Levels are definied as follows:
/// 0 => FATAL,
/// 1 => ERROR,
/// 2 => WARN,
/// 3 => INFO,
/// 4 => VERBOSE
/// </summary>
public static class LogManager
{
    private static Dictionary<string, Logger> _loggers;
    private static int _logLevel;
    private static bool _initialized = false;

    /// <summary>
    /// Initializes the log manager.
    /// </summary>
    /// <param name="logLevel">
    /// The highest log level to be output to the console.
    /// Log Levels are definied as follows:
    /// 0 => FATAL,
    /// 1 => ERROR,
    /// 2 => WARN,
    /// 3 => INFO,
    /// 4 => VERBOSE
    /// </param>
    public static void Initialize(int logLevel)
    {
        _loggers = new Dictionary<string, Logger>();
        _logLevel = logLevel;
        _initialized = true;
    }

    /// <summary>
    /// Returns a logger that exists in the LogManager.
    /// </summary>
    /// <param name="name">The name of the logger to e returned.</param>
    /// <returns>The logger correspondining to the name supplied.</returns>
    public static Logger GetLogger(string name)
    {
        Logger _logger = null;

        if (_loggers.ContainsKey(name))
        {
            _logger = _loggers[name];
        }

        return _logger;
    }

    /// <summary>
    /// Adds a logger to the log manager.
    /// </summary>
    /// <param name="name">The name the logger should be added under.</param>
    /// <param name="logger">The logger to be added.</param>
    public static void AddLogger(string name, Logger logger)
    {
        if (!_loggers.ContainsKey(name))
        {
            _loggers.Add(name, logger);
        }
    }

    /// <summary>
    /// Removes an existing logger.
    /// </summary>
    /// <param name="name">The name of the logger to be removed.</param>
    public static void RemoveLogger(string name)
    {
        if (_loggers.ContainsKey(name))
        {
            _loggers.Remove(name);
        }
    }

    /// <summary>
    /// Replaces an existing logger with a new one using the same name.
    /// </summary>
    /// <param name="name">The name of the logger to be replaced.</param>
    /// <param name="replacement">The logger to replaces the existing one.</param>
    public static void ReplaceLogger(string name, Logger replacement)
    {
        RemoveLogger(name);
        AddLogger(name, replacement);
    }

    /// <summary>
    /// Uses a logger to write a message to a log. Also write the message to the conosle if the log level is low enough.
    /// </summary>
    /// <param name="logLevel">
    /// The level of the message that is to be written to the log.
    /// Log Levels are definied as follows:
    /// 0 => FATAL,
    /// 1 => ERROR,
    /// 2 => WARN,
    /// 3 => INFO,
    /// 4 => VERBOSE
    /// </param>
    /// <param name="logName">The name to be used to look up the logger to use.</param>
    /// <param name="message">The message that is to be written to the log.</param>
    public static void WriteLog(int logLevel, string logName, string message)
    {
        var logMessage = $"{ParseLogLevel(logLevel)} : {message}";
        if (logLevel <= _logLevel)
        {
            Console.WriteLine(logMessage);
        }

        GetLogger(logName).WriteLog(logLevel, message);
    }

    /// <summary>
    /// Parses an integer log level into a string of the english log level.
    /// </summary>
    /// <param name="logLevel">The integer to be parsed.</param>
    /// <returns>A string with the english log level.</returns>
    public static string ParseLogLevel(int logLevel)
    {
        switch (logLevel)
        {
            case (0): { return "FATAL"; };
            case (1): { return "ERROR"; };
            case (2): { return "WARN"; };
            case (3): { return "INFO"; };
            case (4): { return "VEROSE"; };
            default: { return $"UNKNOWN_LOG_LEVEL({logLevel})"; };
        }
    }
}