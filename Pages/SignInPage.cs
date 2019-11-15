using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace Framework2
{
    public class SignInPage : BaseAppPage
    {
        private IWebElement submitButton => Driver.FindElement(By.Id("SubmitLogin"));
        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        public bool PageIsLoadedCorrectly()
        {
            Reporter.LogPassingTestStepToBugLogger($"Checking if SingIn loadec correctly.");
            return submitButton.Displayed;
        }
    }
}