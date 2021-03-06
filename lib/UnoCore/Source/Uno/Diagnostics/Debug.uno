using Uno.Compiler.ExportTargetInterop;
using System;

namespace Uno.Diagnostics
{
    [Obsolete("Please use Uno.Diagnostics.LogLevel instead.")]
    public enum DebugMessageType
    {
        Debug,
        Information,
        Warning,
        Error,
        Fatal,
    }

    [Obsolete]
    public delegate void AssertionHandler(bool value, string expression, string filename, int line, params object[] operands);

    [Obsolete("Please use the Uno.Diagnostics.Log class instead.")]
    public delegate void LogHandler(string message, DebugMessageType type);

    [Obsolete("Please use the Uno.Diagnostics.Log class instead.")]
    public static class Debug
    {
        static AssertionHandler _assertionHandler;

        [Obsolete]
        public static void SetAssertionHandler(AssertionHandler handler)
        {
            _assertionHandler = handler;
        }

        [Obsolete("Please use the Uno.Testing.Assert class instead.")]
        public static void Assert(bool value, string expression, string filename, int line, params object[] operands)
        {
            if (_assertionHandler != null)
            {
                _assertionHandler(value, expression, filename, line, operands);
            }
            if (!value)
            {
                EmitLog("Assertion Failed: '" + expression + "' in " + filename + "(" + line + ")", DebugMessageType.Error);
            }
        }

        static LogHandler _logHandler;

        [Obsolete("Please use the Uno.Diagnostics.Log class instead.")]
        public static void SetLogHandler(LogHandler handler)
        {
            _logHandler = handler;
        }

        [Obsolete("Please use the Uno.Diagnostics.Log class instead.")]
        public static void Log(string message, DebugMessageType type, string filename, int line)
        {
            EmitLog(message, type);
        }

        [Obsolete("Please use the Uno.Diagnostics.Log class instead.")]
        public static void Log(object message, DebugMessageType type, string filename, int line)
        {
            EmitLog((message ?? string.Empty).ToString(), type);
        }

        [Obsolete("Please use the Uno.Diagnostics.Log class instead.")]
        public static void Log(string message, DebugMessageType type = 0)
        {
            EmitLog(message, type);
        }

        [Obsolete("Please use the Uno.Diagnostics.Log class instead.")]
        public static void Log(object message, DebugMessageType type = 0)
        {
            EmitLog(message.ToString(), type);
        }

        static string _indentStr = "";

        [Obsolete]
        public static void IndentLog()
        {
            _indentStr += "\t";
        }

        [Obsolete]
        public static void UnindentLog()
        {
            _indentStr = _indentStr.Substring( 0, _indentStr.Length - 1 );
        }

        [Obsolete]
        static void EmitLog(string message, DebugMessageType type)
        {
            Diagnostics.Log.WriteLine((LogLevel)type, message);
        }
    }
}
