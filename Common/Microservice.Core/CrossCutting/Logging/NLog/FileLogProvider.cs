using Microsoft.Extensions.Logging;

namespace Microservice.Core.CrossCutting.Logging.NLog
{
    public class FileLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}