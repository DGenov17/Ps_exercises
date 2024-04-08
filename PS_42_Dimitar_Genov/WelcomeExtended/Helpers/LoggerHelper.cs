using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    public static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFacory = new LoggerFactory();
            loggerFacory.AddProvider(new LoggerProvider());

            return loggerFacory.CreateLogger(categoryName);
        }
    }
}
