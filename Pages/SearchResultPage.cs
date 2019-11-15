using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Framework2
{
    public class SearchResultPage : BaseAppPage
    {
        //Elements found counter
        private IWebElement CountElements => Driver.FindElement(By.XPath("//*[@class='product-count']"));

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
        }

        public bool ProductIsVisible => CountElements.Displayed;
    }
}