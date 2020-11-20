using System;

namespace Unicorn.Logging
{
    public class LoggingSettings
    {
        public bool IsEnabled { get; internal set; }
        public bool IsConsoleLoggingEnabled { get; internal set; }
        public string OutputTemplate { get; internal set; }
        public bool IsDebugLoggingEnabled { get; internal set; }
        public bool IsFileLoggingEnabled { get; internal set; }
    }
}
