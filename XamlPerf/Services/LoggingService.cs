using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Diagnostics;

namespace XamlPerf.Services
{
    public static class LoggingService
    {
        public static void AddUserMark(string message)
        {
            using (var channel = new LoggingChannel(Guid.Empty.ToString()))
            {
                channel.LogMessage(message, LoggingLevel.Information);
            }
        }
    }
}
