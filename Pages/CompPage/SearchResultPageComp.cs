using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using ApplicationFactory;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Framework2
{
    public class SearchResultPageComp : BaseAppPage
    {
        public SearchResultPageComp(IWebDriver driver) : base(driver)
        {

        }

        public bool CheckIfSelError()
        {
            return (Driver.Title == "You searched for selenium error - Ultimate QA");
        }
    }
}