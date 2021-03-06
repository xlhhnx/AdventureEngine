﻿using System.Collections.Generic;

namespace AdventureEngine.Logging
{
    public class LogManager
    {
        /// <summary>
        /// Gets the path for the default error log.
        /// </summary>
        public string DefaultErrorLogPath { get { return _defualtErrorLogPath; } }

        protected string _defualtErrorLogPath;
        protected Dictionary<string, Logger> _loggers;

        /// <summary>
        /// Constructs a log manager.
        /// </summary>
        /// <param name="defaultErrorLogPath">The file path for the default error log.</param>
        public LogManager(string defaultErrorLogPath)
        {
            _defualtErrorLogPath = defaultErrorLogPath;

            _loggers = new Dictionary<string, Logger>();

            var defaultErrorLogger = new Logger(defaultErrorLogPath, LogLevel.FATAL);
            _loggers.Add(defaultErrorLogPath, defaultErrorLogger);
        }

        /// <summary>
        /// Checks if a filePath is a key in the logger dictionary.
        /// </summary>
        /// <param name="filePath">The file path to be checked against the logger dictionary.</param>
        /// <returns>A bool describing whether the filePath provided is a key in the logger dictionary.</returns>
        public bool ContainsLogger(string filePath)
        {
            return _loggers.ContainsKey(filePath);
        }

        /// <summary>
        /// Gets a logger from the logger dicionary if it exists.
        /// </summary>
        /// <param name="filePath">The file path used to look up the correct logger.</param>
        /// <returns>A logger or null.</returns>
        public Logger GetLogger(string filePath)
        {
            if (ContainsLogger(filePath))
            {
                return _loggers[filePath];
            }
            else
            {
                Write(_defualtErrorLogPath, $"Failed to get logger with filePath={filePath}.", LogLevel.ERROR);
                return null;
            }
        }

        /// <summary>
        /// Writes a loglogMessage to a file using a logger found with the file path.
        /// </summary>
        /// <param name="filePath">The file path used to determine which logger to use to write the loglogMessage.</param>
        /// <param name="logMessage">A loglogMessage to be written to the log.</param>
        public void Write(string filePath, string logMessage)
        {
            if (ContainsLogger(filePath))
            {
                _loggers[filePath].Write(logMessage);
            }
            else
            {
                Write(_defualtErrorLogPath, $"Failed to find logger with filePath={filePath}. Failed to write loglogMessage='{logMessage}'", LogLevel.ERROR);
            }
        }

        /// <summary>
        /// Writes a logMessage to a file using a logger found with the file path.
        /// </summary>
        /// <param name="filePath">The file path used to determine which logger to use to write the logMessage.</param>
        /// <param name="logMessage">A logMessage to be written to the log.</param>
        /// <param name="logLevel">The log level this logMessage should be logged under.</param>
        public void Write(string filePath, string logMessage, LogLevel logLevel)
        {
            if (ContainsLogger(filePath))
            {
                _loggers[filePath].Write(logMessage, logLevel);
            }
            else
            {
                Write(_defualtErrorLogPath, $"Failed to find logger with filePath={filePath}. Failed to write logMessage='{logMessage}'", LogLevel.ERROR);
            }
        }
    }
}