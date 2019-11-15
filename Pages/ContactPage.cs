using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using ApplicationFactory;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Framework2
{
    public class ContactPage : BaseAppPage
    {
        string successMessageLocator = "//*[@class='alert alert-success']";
        private IWebElement SuccessMessage => Driver.FindElement(By.XPath($"{successMessageLocator}"));
        private SelectElement Subject => new SelectElement(Driver.FindElement(By.Id("id_contact")));
        private IWebElement EMailField => Driver.FindElement(By.Id("email"));
        private IWebElement OrderRererence => Driver.FindElement(By.Id("id_order"));
        private IWebElement FileField => Driver.FindElement(By.Id("fileUpload"));
        private IWebElement MessageField => Driver.FindElement(By.Id("message"));
        private IWebElement SendButton => Driver.FindElement(By.Id("submitMessage"));
        private IWebElement ContactMessage => Driver.FindElement(By.XPath("//*[@class='page-heading bottom-indent']"));

        public ContactPage(IWebDriver driver) : base(driver)
        {

        }

        public void FillFormAndClickSubmit(Message message)
        {
            //Fill form
            Subject.SelectByText("Webmaster");
            EMailField.SendKeys(message.Email);
            OrderRererence.SendKeys(message.Order);
            FileField.SendKeys(message.File);
            MessageField.SendKeys(message.MessageBody);
            //Click 'Send' button
            SendButton.Click();
        }

        public bool MessageWasSendCorrectly()
        {
            TimeSpan ts = TimeSpan.FromSeconds(5);
            WebDriverWait wait = new WebDriverWait(Driver, ts);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"{successMessageLocator}")));

            return SuccessMessage.Displayed;
        }

        public bool PageIsLoadedCorrectly()
        {
            Reporter.LogPassingTestStepToBugLogger($"Open url for Contact Us page.");
            return ContactMessage.Displayed;
        }
    }
}