using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;

namespace Framework2
{
    public class MainPage : BaseAppPage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        //Logo of main page
        private IWebElement MainPageLogo => Driver.FindElement(By.XPath("//*[@class='logo img-responsive']"));
        //Search field
        private IWebElement SearchField => Driver.FindElement(By.Id("search_query_top"));
        //Search button
        private IWebElement SearchButton => Driver.FindElement(By.XPath("//*[@class='btn btn-default button-search']"));

        private IWebElement ContactUsLink => Driver.FindElement(By.LinkText("Contact us"));
        private IWebElement SingInLink => Driver.FindElement(By.LinkText("Sign in"));

        internal Slider Slider { get; private set; }

        public MainPage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        public void GoTo()
        {
            string url = "http://automationpractice.com/index.php";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"In a browser, go to url=>{url}");
            _logger.Info($"Open url {url}");
            Assert.IsTrue(MainPageLogo.Displayed);
        }

        public SearchResultPage FillSearchFieldAndClick()
        {
            SearchField.SendKeys("Blouse");
            SearchButton.Click();

            return new SearchResultPage(Driver);
        }

        public ContactPage ClickContactUsLink()
        {
            Reporter.LogPassingTestStepToBugLogger($"In a browser, on Main page, click ContackUs");
            ContactUsLink.Click();
            return new ContactPage(Driver);
        }

        public SignInPage ClickSignInLink()
        {
            Reporter.LogPassingTestStepToBugLogger($"In a browser, on Main page, click Sing In");
            SingInLink.Click();
            return new SignInPage(Driver);
        }
    }
}