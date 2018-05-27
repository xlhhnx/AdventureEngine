using Microsoft.Xna.Framework.Content;
using System;
using System.IO;

public static class LoadingConfiguration
{
    /// <summary>
    /// Gets and Sets the default loading logger.
    /// </summary>
    public static Logger Log
    {
        get
        {
            if (_log == null)
            {
                _log = new Logger(Configuration.LoadingLogPath, LogLevel.ERROR);
            }
            return _log;
        }
        set { _log = value; }
    }

    /// <summary>
    /// Gets and Sets the default content manager.
    /// </summary>
    public static ContentManager Content
    {
        get { return _contentManager; }
        set { _contentManager = value; }
    }

    private static Logger _log = null;
    private static ContentManager _contentManager = null;
}