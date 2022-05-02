using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace transcription_project.IntegrationTests.Controllers
{
    public class HomeControllerTest
    {
        public IWebDriver? Driver { get; set; }

        [SetUp]
        public void Setup()
        {
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver",@"C:/Users/HP/GeckoDriver/geckodriver.exe");
            Driver = new FirefoxDriver();
            Driver.Url = "https://localhost:5001/";
        }

        [Test]
        public void LoginTest()
        {
            Driver.Navigate().GoToUrl("https://localhost:5001/login");

            var usernameLocator = By.CssSelector("#username");
            var passwordLocator = By.CssSelector("#password");
            var submitLocator = By.CssSelector(".login");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(drv => drv.FindElement(usernameLocator));

            var usernameElement = Driver.FindElement(usernameLocator);
            var passwordElement = Driver.FindElement(passwordLocator);
            var submitElement = Driver.FindElement(submitLocator);

            usernameElement.SendKeys("johndoe1237");
            passwordElement.SendKeys("123456787");
            submitElement.Click();

            Assert.AreEqual("https://localhost:5001/Home/Index", Driver.Url);
        }

        [TearDown]
        public void Teardown()
        {

            Driver.Close();
        }
    }
}