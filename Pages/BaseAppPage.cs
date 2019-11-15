using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Framework2
{
    public class BaseAppPage
    {
        public IWebDriver Driver { get; }
        public BaseAppPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
