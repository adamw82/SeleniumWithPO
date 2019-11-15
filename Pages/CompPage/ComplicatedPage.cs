using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Framework2
{
    public class ComplicatedPage : BaseAppPage
    {
        private IWebElement SectionOfRamdom => Driver.FindElement(By.Id("Section_of_Random_Stuff"));
        private IWebElement NameInForm => Driver.FindElement(By.Id("et_pb_contact_name_0"));
        private IWebElement EmailInForm => Driver.FindElement(By.Id("et_pb_contact_email_0"));
        private IWebElement MessagelInForm => Driver.FindElement(By.Id("et_pb_contact_message_0"));
        private IWebElement CaptchaForm => Driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
        private IWebElement SubmitCaptchaForm => Driver.FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"));
        private IWebElement SubmitCButtonForm => Driver.FindElement(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"));
        private IWebElement IfSubmitted => Driver.FindElement(By.XPath("//*[@id='et_pb_contact_form_0']/div"));
        internal LeftSlider LeftSlider { get; private set; }
        internal SocialMediaBar SocialMediaBar { get; private set; }

        public ComplicatedPage(IWebDriver driver) : base(driver)
        {
            LeftSlider = new LeftSlider(driver);
            SocialMediaBar = new SocialMediaBar(driver);
        }

        public void Goto()
        {
            string url = "https://ultimateqa.com/complicated-page/";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"In a browser, go to url=>{url}");
            Assert.IsTrue(SectionOfRamdom.Displayed);
        }

        public void FillAndSubmitForm()
        {
            NameInForm.SendKeys("teswwwt");
            EmailInForm.SendKeys("test@wp.pl");
            MessagelInForm.SendKeys("bssssssssssla");
            Reporter.LogPassingTestStepToBugLogger($"Fill form with data");
            string[] captchaInt = CaptchaForm.Text.Split('+');
            string resultCapchta = Convert.ToString(Convert.ToInt32(captchaInt[0]) + Convert.ToInt32(captchaInt[1]));
            SubmitCaptchaForm.SendKeys(resultCapchta);
            Reporter.LogPassingTestStepToBugLogger($"Fill captcha");
            SubmitCButtonForm.Click();
            Reporter.LogPassingTestStepToBugLogger($"Click submit button.");
        }

        public bool CheckIfSubmited()
        {
            TimeSpan ts = TimeSpan.FromSeconds(5);
            WebDriverWait wait = new WebDriverWait(Driver, ts);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='et_pb_contact_form_0']/div")));

            string test2 = IfSubmitted.Text;
            string expected = "Thanks for contacting us";
            if (test2 == expected)
            {
                return true;
            }
            else
            {
                Reporter.LogPassingTestStepToBugLogger($"Problem with submiting form.\n Displayed text is not correct - {test2}. Expected is - {expected}");
                return false;
            }
                
        }
    }
}