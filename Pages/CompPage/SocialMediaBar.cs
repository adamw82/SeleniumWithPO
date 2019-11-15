using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Framework2
{
    public class SocialMediaBar : BaseAppPage
    {
        private IWebElement LinkedInButton => Driver.FindElement(By.XPath("//*[@class='nc_tweetContainer swp_share_button swp_linkedin']"));
        public SocialMediaBar(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLinkedIn()
        {
            LinkedInButton.Click();
        }

        public bool CheckIfUrlContainLinkedIn()
        {
            var currentWindow = Driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle -> " + currentWindow);

            ClickLinkedIn();

            var availableWindows = new List<string>(Driver.WindowHandles);

            foreach (string w in availableWindows)
            {
                if (w != currentWindow)
                {
                    Driver.SwitchTo().Window(w);
                    if (Driver.Url.Contains("linkedin"))
                        return true;
                    else
                    {
                        Driver.SwitchTo().Window(currentWindow);
                    }

                }
            }
            return false;
        }
    }
}