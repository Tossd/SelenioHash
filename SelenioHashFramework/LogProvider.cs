using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelenioHashFramework
{
    public static class LogProvider
    {
        public static ILogger DefaultLogger
        {
            get
            {
                return new ConsoleLogger();
            }
        }
    }
}
