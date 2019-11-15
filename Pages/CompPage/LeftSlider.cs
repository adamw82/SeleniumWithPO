using System;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Framework2
{
    public class LeftSlider : BaseAppPage
    {
        private IWebElement LeftSearchField => Driver.FindElement(By.Id("s"));

        public IWebElement SearchButton => Driver.FindElement(By.Id("searchsubmit"));

        public LeftSlider(IWebDriver driver) : base(driver)
        {
        }

        public SearchResultPageComp FillSearchandClick()
        {
            LeftSearchField.SendKeys("selenium error");
            SearchButton.Click();
            return new SearchResultPageComp(Driver);
        }
    }
}