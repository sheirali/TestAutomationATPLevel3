using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Configuration;
using Unicorn.Web.Model;

namespace Unicorn.Web.Services
{
    public partial class DriverFactory : IDisposable
    {
        private bool _disposed;

        public void Start(BrowserConfiguration browserConfiguration)
        {
            _disposed = false;
            switch (browserConfiguration.ExecutionType)
            {
                case ExecutionType.Regular:
                    StartBrowserRegularMode(browserConfiguration);
                    break;
                case ExecutionType.Grid:
                    break;
                case ExecutionType.SauceLabs:
                    break;
                case ExecutionType.BrowserStack:
                    break;
                case ExecutionType.CrossBrowserTesting:
                    break;
            }
        }

        private void StartBrowserRegularMode(BrowserConfiguration browserConfiguration)
        {
            IWebDriver driver = default;

            switch (browserConfiguration.Browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(Environment.CurrentDirectory);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Chrome.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Chrome.ScriptTimeout);
                    driver.Manage().Window.Maximize();
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver(Environment.CurrentDirectory);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().FireFox.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().FireFox.ScriptTimeout);
                    driver.Manage().Window.Maximize();
                    break;
                case Browser.Edge:
                    driver = new EdgeDriver(Environment.CurrentDirectory);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Edge.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Edge.ScriptTimeout);
                    driver.Manage().Window.Maximize();
                    break;
                case Browser.Safari:
                    driver = new SafariDriver(Environment.CurrentDirectory);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Safari.PageLoadTimeout);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(ConfigurationService.GetSection<WebSettings>().Safari.ScriptTimeout);
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserConfiguration.Browser), browserConfiguration.BrowserBehavior.ToString());
            }

            ServiceContainer.RegisterInstance(driver);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                var driver = ServiceContainer.Resolve<IWebDriver>();
                driver?.Quit();
                driver?.Dispose();

                ServiceContainer.UnRegisterInstance<IWebDriver>();
                GC.SuppressFinalize(this);

                _disposed = true;
            }
        }
    }
}