using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ApplicationFactory;

namespace Framework2
{
    [TestClass]
    [TestCategory("APP_Two")]
    public class Tests : BaseTest
    {
        internal Message NewMessage { get; set; }

        [TestMethod]
        public void SearchForProduct()
        {
            var searchPageResult = TheMainPage.FillSearchFieldAndClick();     
            Assert.IsTrue(searchPageResult.ProductIsVisible);
        }

        [TestMethod]
        public void GoToContactPageAndSendMessage()
        {
            var contactPage = TheMainPage.ClickContactUsLink();

            string filePath = WebDriverFactory.CreateFileAndReturnPath();
            Message message = new Message("a@wp.pl", "test", filePath, "messae");

            contactPage.FillFormAndClickSubmit(message);
            Assert.IsTrue(contactPage.MessageWasSendCorrectly());
        }

        [TestMethod]
        [Description("Check if slider is working correctly. Click next button and check if picture has been changed.")]
        public void TC3()
        {
            var currentImage = TheMainPage.Slider.CurrentImage;
            TheMainPage.Slider.ClickNextButton();
            var newImage = TheMainPage.Slider.CurrentImage;
            TheMainPage.Slider.AssertThatImageChanged(currentImage, newImage);
        }

        [TestMethod]
        [Description("Check if ContactUs page is loading correctly.")]
        public void TC4()
        {
            var contactPage = TheMainPage.ClickContactUsLink();
            Assert.IsTrue(contactPage.PageIsLoadedCorrectly());
        }

        [TestMethod]
        [Description("Check if SignIn page is loading correctly.")]
        public void TC5()
        {
            var signInPage = TheMainPage.ClickSignInLink();
            Assert.IsTrue(signInPage.PageIsLoadedCorrectly());
        }

        // ComplicatedPage tests

        [TestMethod]
        [Description("Check if can send form using submit form  on ComplicatedPage.")]
        public void TC6()
        {
            ComplicatedPage complicated = new ComplicatedPage(Driver);
            complicated.Goto();
            complicated.FillAndSubmitForm();
            Assert.IsTrue(complicated.CheckIfSubmited(), "");
        }

        [TestMethod]
        [Description("Check if left search pane is working")]
        public void TC7()
        {
            ComplicatedPage complicated = new ComplicatedPage(Driver);
            complicated.Goto();
            SearchResultPageComp searchPage = complicated.LeftSlider.FillSearchandClick();
            Assert.IsTrue(searchPage.CheckIfSelError()," OK.");
        }

        [TestMethod]
        [Description("Check if Linkedin window was open for log in")]
        public void TC8()
        {
            ComplicatedPage complicated = new ComplicatedPage(Driver);
            complicated.Goto();
            Assert.IsTrue(complicated.SocialMediaBar.CheckIfUrlContainLinkedIn(), " OK.");
        }

        // Drag and drop test

        [TestMethod]
        [Description("Check drag and drop")]
        public void TC9()
        {
            DragAndDropPage dragAndDrop = new DragAndDropPage(Driver);
            dragAndDrop.GotoUrl1();
            Assert.AreEqual("Dropped!", dragAndDrop.DropElementAndCheckMessage1());
        }
    }
}
