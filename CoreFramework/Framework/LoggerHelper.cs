using log4net.Appender;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Layout;
using log4net.Core;
using log4net.Config;

namespace SeleniumDemo.Framework
{
    public class LoggerHelper
    {
        #region Fields
        private static RollingFileAppender _rollingFileAppender;
        private static FileAppender _fileAppender;
        private static ConsoleAppender _consoleAppender;
        private static ILog _logger;
        private static string _layout = "%date{ dd-MMM-yyyy-HH:mm: ss}- [%level] - %class - %method -%message%newline";
        #endregion

        #region Properties

        public static string Layout
        { set
            {
                _layout = value;
            }
        }

        #endregion

        #region PrivateMembers

        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingFileAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "RollingFileLogger.log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 15

            };
            rollingFileAppender.ActivateOptions();
            return rollingFileAppender;
        }

        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "File Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log"

            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "Console Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.Error
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }
        #endregion

        #region PublicMethods
        public static ILog GetLogger(Type type)
        {
            if (_rollingFileAppender == null)
                _rollingFileAppender = GetRollingFileAppender();

            if (_fileAppender == null)
                _fileAppender = GetFileAppender();

            if (_consoleAppender == null)
                _consoleAppender = GetConsoleAppender();

            if (_logger != null)
                return _logger;

            BasicConfigurator.Configure(_rollingFileAppender, _fileAppender, _consoleAppender);
            _logger = LogManager.GetLogger(type);
            _logger.Info("-----------Starting Logging------------");
            return _logger;
        }

        #endregion
    }
}
