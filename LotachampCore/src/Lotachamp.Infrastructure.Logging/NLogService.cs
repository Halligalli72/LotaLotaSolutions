using Lotachamp.Application.Infrastructure;
using NLog;
using System;

namespace Lotachamp.Infrastructure.Logging
{
    public class NLogService : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }


        public void LogError(Exception ex, string message)
        {
            logger.Error($"{message}: {ex.Message}");
            logger.Error($"StackTrace: {ex.StackTrace}");
            if (ex.InnerException != null)
                logger.Error($"InnerException: {ex.InnerException.Message}");
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
