using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Application.Interfaces
{
    public interface ILoggerService
    {

        void LogInfo(Type caller, string message);

        void LogInfo(Type caller, string message, params object[] args);

        void LogError(Type caller, string message, params object[] args);

        void LogError(Type caller, Exception ex, string message, params object[] args);

        void LogError(Type caller, Exception ex, string message = null);

        void LogWarn(Type caller, Exception ex, string message = null);

        void LogWarn(Type caller, string message);

        void LogWarn(Type caller, string message, params object[] args);

        void LogDebug(Type caller, string message, params object[] args);

        void LogDebug(Type caller, string message);
    }
}
