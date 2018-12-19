using System;

namespace ECommerce.Core.Logging
{
    public interface ILogger
    {
        void Log(string text);

        void LogError(Exception ex);
    }
}
