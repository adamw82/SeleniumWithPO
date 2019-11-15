using ApplicationFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using NLog;

namespace Framework2
{
    public class BaseTest
    {
        internal IWebDriver Driver { get; set; }
        internal MainPage TheMainPage { get; set; }

        //private static TestContext _testContext;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void StartBeforeTest()
        {
            Logger.Debug("*************************************** TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            var Factory = new WebDriverFactory();
            Driver = Factory.Create(BrowserType.Chrome);
            TheMainPage = new MainPage(Driver);
            TheMainPage.GoTo();
            Driver.Manage().Window.Maximize();
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }

        [TestCleanup]
        public void TearDownForEverySingleTestMethod()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }
    }
}