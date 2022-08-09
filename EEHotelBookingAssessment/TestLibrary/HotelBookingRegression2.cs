using EEHotelBookingAssessment.Helpers;
using OpenQA.Selenium;
using EEHotelBookingAssessment.Static;

namespace EEHotelBookingAssessment.TestLibrary
{
    public class HotelBookingRegression2 : NunitTestbase
    {
        [TestCase("AddClientDetailsWithBlankFirstName", "", "TesterSurname", "299.99", "false", "2022-08-30", "2022-09-01")]
        public void AddClientDetailsWithFirstNameBlank(string screenshotname, string firstname, string lastname, string price, string depositpaid, string checkin, string checkout)
        {
            InitBrowser("Chrome");
            LoadWebsite(ConfigData.HotelBookingWebsite);
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("totalprice")).Clear();
            Driver.FindElement(By.Id("totalprice")).SendKeys(price);
            Driver.FindElement(By.Id("depositpaid")).SendKeys(depositpaid);
            Driver.FindElement(By.Id("checkin")).SendKeys(checkin);
            Driver.FindElement(By.Id("checkout")).SendKeys(checkout);
            Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
            Thread.Sleep(1500);
            var lastbookingfirstname = response.GetLastBookingFirstanme();
            Assert.That(lastbookingfirstname, Is.Not.EqualTo(firstname));
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }

        [TestCase("AddClientDetailsWithLastNameBlank", "TesterCPT", "", "299.99", "false", "2022-08-30", "2022-09-01")]
        public void AddClientDetailsWithLastNameBlank(string screenshotname, string firstname, string lastname, string price, string depositpaid, string checkin, string checkout)
        {
            InitBrowser("Chrome");
            LoadWebsite(ConfigData.HotelBookingWebsite);
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("totalprice")).Clear();
            Driver.FindElement(By.Id("totalprice")).SendKeys(price);
            Driver.FindElement(By.Id("depositpaid")).SendKeys(depositpaid);
            Driver.FindElement(By.Id("checkin")).SendKeys(checkin);
            Driver.FindElement(By.Id("checkout")).SendKeys(checkout);
            Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
            Thread.Sleep(1500);
            var lastbookingfirstname = response.GetLastBookingFirstanme();
            Assert.That(lastbookingfirstname, Is.Not.EqualTo(firstname));
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }

        [TestCase("AddClientDetailsWithPriceBlank", "TesterCPT", "TesterSurname", "", "false", "2022-08-30", "2022-09-01")]
        public void AddClientDetailsWithPriceBlank(string screenshotname, string firstname, string lastname, string price, string depositpaid, string checkin, string checkout)
        {
            InitBrowser("Chrome");
            LoadWebsite(ConfigData.HotelBookingWebsite);
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("totalprice")).Clear();
            Driver.FindElement(By.Id("totalprice")).SendKeys(price);
            Driver.FindElement(By.Id("depositpaid")).SendKeys(depositpaid);
            Driver.FindElement(By.Id("checkin")).SendKeys(checkin);
            Driver.FindElement(By.Id("checkout")).SendKeys(checkout);
            Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
            Thread.Sleep(1500);
            var lastbookingfirstname = response.GetLastBookingFirstanme();
            Assert.That(lastbookingfirstname, Is.Not.EqualTo(firstname));
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }

        [TestCase("AddClientDetailsWithBlankCheckin", "TesterCPT", "TesterSurname", "299.99", "false", "", "2022-09-01")]
        public void AddClientDetailsWithBlankCheckin(string screenshotname, string firstname, string lastname, string price, string depositpaid, string checkin, string checkout)
        {
            InitBrowser("Chrome");
            LoadWebsite(ConfigData.HotelBookingWebsite);
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("totalprice")).Clear();
            Driver.FindElement(By.Id("totalprice")).SendKeys(price);
            Driver.FindElement(By.Id("depositpaid")).SendKeys(depositpaid);
            Driver.FindElement(By.Id("checkin")).SendKeys(checkin);
            Driver.FindElement(By.Id("checkout")).SendKeys(checkout);
            Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
            Thread.Sleep(1500);
            var lastbookingfirstname = response.GetLastBookingFirstanme();
            Assert.That(lastbookingfirstname, Is.Not.EqualTo(firstname));
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }

        [TestCase("AddClientDetailsWithBlankCheckout", "TesterCPT", "TesterSurname", "299.99", "false", "2022-08-30", "")]
        public void AddClientDetailsWithBlankCheckout(string screenshotname, string firstname, string lastname, string price, string depositpaid, string checkin, string checkout)
        {
            InitBrowser("Chrome");
            LoadWebsite(ConfigData.HotelBookingWebsite);
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
            Driver.FindElement(By.Id("lastname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
            Driver.FindElement(By.Id("totalprice")).Clear();
            Driver.FindElement(By.Id("totalprice")).SendKeys(price);
            Driver.FindElement(By.Id("depositpaid")).SendKeys(depositpaid);
            Driver.FindElement(By.Id("checkin")).SendKeys(checkin);
            Driver.FindElement(By.Id("checkout")).SendKeys(checkout);
            Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
            Thread.Sleep(1500);
            var lastbookingfirstname = response.GetLastBookingFirstanme();
            Assert.That(lastbookingfirstname, Is.Not.EqualTo(firstname));
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }
    }
}
