using System;
using System.Configuration;
using OpenQA.Selenium.Remote;

namespace SelenioHashFramework
{
    public static class Configuration
    {
        public static string Driver { get { return ConfigurationManager.AppSettings["driver"] ?? "firefox"; } }

        public static string Runner { get { return ConfigurationManager.AppSettings["runner"] ?? "local"; } }

        public static int HubPort
        {
            get
            {
                int port;
                return int.TryParse(ConfigurationManager.AppSettings["hubport"], out port) ? port : 4444;
            }
        }

        public static string HubHost
        {
            get { return ConfigurationManager.AppSettings["hubhost"] ?? "localhost"; }
        }

        public static string BrowserUrl
        {
            get { return ConfigurationManager.AppSettings["browserurl"] ?? "http://www.google.com"; }
        }

        public static string GetBrowserString(string driver)
        {
            switch (driver.ToLower())
            {
                case "firefox":
                    return "*firefox";
                case "chrome":
                    return "*chrome";
                case "ie":
                case "iexplore":
                case "internetexplorer":
                    return "*iexplore";
                default:
                    throw new Exception("Unrecognized driver type: " + driver + ". Could not get appropriate browser string");
            }
        }

        public static DesiredCapabilities GetDesiredCapability(string driver)
        {
            switch (driver.ToLower())
            {
                case "firefox":
                    return DesiredCapabilities.Firefox();
                case "chrome":
                    return DesiredCapabilities.Chrome();
                case "ie":
                case "iexplore":
                case "internetexplorer":
                    return DesiredCapabilities.InternetExplorer();
                default:
                    throw new Exception("Unrecognized driver type: " + driver + ". Could not get appropriate desired capabilities method");
            }
        }

        public static Uri GetRemoteAddress(string host, int port)
        {
            return new Uri("http://" + host + ":" + port + "/wd/hub");
        }

    }
}
