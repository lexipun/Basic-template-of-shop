using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeShop.Loggers
{
    public class OrderLogs
    {
        public ILogger Logger { get; }

        public OrderLogs(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger("Orders");
        }

    }
}
