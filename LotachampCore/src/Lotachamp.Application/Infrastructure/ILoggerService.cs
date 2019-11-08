using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Application.Infrastructure
{
    public interface ILoggerService
    {

        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(Exception ex, string message);
    }
}
