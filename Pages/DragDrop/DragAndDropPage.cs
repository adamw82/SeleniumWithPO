using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Framework2
{
    internal class DragAndDropPage : BaseAppPage
    {
        private IWebElement source => Driver.FindElement(By.Id("draggable"));
        private IWebElement target => Driver.FindElement(By.Id("droppable"));
        public DragAndDropPage(IWebDriver driver) : base(driver)
        {
        }

        public void GotoUrl1()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            Driver.Navigate().GoToUrl("https://jqueryui.com/droppable");

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
        }

        public string DropElement1()
        {
            var action = new Actions(Driver);
            action.DragAndDrop(source, target).Perform();

            return target.Text;
        }
    }
}