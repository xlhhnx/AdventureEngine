using System;

public static class Configuration
{
    /// <summary>
    /// Gets and Sets the start date string.
    /// </summary>
    public static string StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }

    /// <summary>
    /// Gets and Sets the start time string.
    /// </summary>
    public static string StartTime
    {
        get { return _startTime; }
        set { _startTime = value; }
    }

    /// <summary>
    /// Gets the combined start date and time strings.
    /// </summary>
    public static string StartDateTime
    {
        get { return _startDate + _startTime; }
    }

    /// <summary>
    /// Gets and Sets the default master log file path.
    /// </summary>
    public static string MasterLogPath
    {
        get { return _masterLogPath; }
        set { _masterLogPath = value; }
    }

    /// <summary>
    /// Gets and Sets the default loading log file path.
    /// </summary>
    public static string LoadingLogPath
    {
        get { return _loadingLogPath; }
        set { _loadingLogPath = value; }
    }

    private static string _startDate = DateTime.Now.ToString("yyyyMMdd");
    private static string _startTime = DateTime.Now.ToString("hhmmss");
    private static string _masterLogPath = $@"logs\game_{StartDateTime}.log";
    private static string _loadingLogPath = $@"logs\loading_{StartDateTime}.log";
}