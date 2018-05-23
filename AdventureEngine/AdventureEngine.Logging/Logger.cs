using System.IO;
using System.Runtime.InteropServices;

public class Logger
{
    /// <summary>
    /// Gets and Sets the path of the log file.
    /// </summary>
    public string FilePath
    {
        get { return _filePath; }
        set { _filePath = value; }
    }

    /// <summary>
    /// Gets the flag that is true if the file is currently open.
    /// </summary>
    public bool FileOpen { get { return _fileOpen; } }

    /// <summary>
    /// Gets and Sets the default logging level.
    /// </summary>
    public LogLevel DefaultLogLevel
    {
        get { return _defaultLogLevel; }
        set { _defaultLogLevel = value; }
    }

    protected string _filePath;
    protected bool _fileOpen;
    protected LogLevel _defaultLogLevel;
    protected StreamWriter _writer;

    /// <summary>
    /// Constructs a Logger.
    /// </summary>
    /// <param name="filePath">The file path of the log file this logger will write to.</param>
    /// <param name="defaultLogLevel">The default level of logging used if none is specfied.</param>
    /// <param name="mode">The file mode that the file should initially be opened with. Ususally Create or Append. Defaults to Create.</param>
    /// <param name="openFile">A flag determining whetherthe log should be opened in the constructor. Defaults to true.</param>
    public Logger(string filePath, LogLevel defaultLogLevel, FileMode mode = FileMode.Create, bool openFile = true)
    {
        _filePath = filePath;
        _defaultLogLevel = defaultLogLevel;

        _fileOpen = false;

        if (openFile)
        {
            OpenFile(mode);
        }
    }

    /// <summary>
    /// Opens the log file.
    /// </summary>
    /// <param name="mode">The file mode that the file should be opened with. Ususally Create or Append.</param>
    public void OpenFile(FileMode mode)
    {
        _writer = new StreamWriter(
            File.Open(_filePath, mode, FileAccess.Write)
            );
        _fileOpen = true;
    }

    /// <summary>
    /// Closes the log file.
    /// </summary>
    public void CloseFile()
    {
        _fileOpen = false;
        _writer.Dispose();
    }

    /// <summary>
    /// Writes a logMessage into the log file using the default log level.
    /// </summary>
    /// <param name="logMessage">The logMessage to be logged.</param>
    public void Write(string logMessage)
    {
        if (_fileOpen)
        {
            _writer.WriteLine($"{_defaultLogLevel} : {logMessage}");
        }
    }

    /// <summary>
    /// Writes a logMessage into the log file using the provided log level.
    /// </summary>
    /// <param name="logMessage">The logMessage to be logged.</param>
    /// <param name="logLevel">The log level this logMessage should be logged under.</param>
    public void Write(string logMessage, LogLevel logLevel)
    {
        if (_fileOpen)
        {
            _writer.WriteLine($"{logLevel} : {logMessage}");
        }
    }
}