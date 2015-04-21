using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SelenioHashFramework
{
    public enum AvailableDrivers
    {
        Firefox,
        Chrome
    }

    public enum ExecutionType
    {
        Sequence,
        Parallel
    }

    internal static class DriverProvider
    {
        public static IWebDriver GetDriver(string driver)
        {
            switch (driver.ToLower())
            {
                case "firefox":
                    return Firefox;
                case "chrome":
                    return Chrome;
                case "ie":
                case "iexplore":
                case "internetexplorer":
                    return InternetExplorer;
                default:
                    throw new Exception("Unrecognized driver type: " + driver);
            }
        }

        private static IWebDriver Firefox
        {
            get { return new FirefoxDriver(); }
        }

        private static IWebDriver Chrome
        {
            get { return new ChromeDriver(); }
        }

        private static IWebDriver InternetExplorer
        {
            get
            {
                return new InternetExplorerDriver();
            }
        }
    }
}
