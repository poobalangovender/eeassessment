using EEHotelBookingAssessment.Helpers;
using OpenQA.Selenium;
using EEHotelBookingAssessment.Static;

namespace EEHotelBookingAssessment.TestLibrary
{
    public class HotelBookingRegression1 : NunitTestbase
    {
        //public APITestHelpers response = new();

        [TestCase("HotelBookingForm")]
        public void LoadHotelBookingForm(string screenshotname)
        {
            InitBrowser("Chrome");
            LoadWebsite(ConfigData.HotelBookingWebsite);
            Thread.Sleep(1500);
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }

        [TestCase("AddClientDetails", "TesterCPT", "TesterSurname", "299.99", "false", "2022-08-30", "2022-09-01")]
        public void AddClientDetails(string screenshotname, string firstname, string lastname, string price, string depositpaid, string checkin, string checkout )
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
            Assert.That(lastbookingfirstname, Is.EqualTo(firstname));
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }

        [TestCase("DeleteClientDetails","TesterCPT")]
        public void DeleteMyClientBookingDetails(string screenshotname, string firstname)
        {
            var lastbookingfirstname = response.GetLastBookingFirstanme(); 
            
            if (lastbookingfirstname == firstname)
            {
                var bookingid = response.GetLastBookingID();

                InitBrowser("Chrome");
                LoadWebsite(ConfigData.HotelBookingWebsite);
                Driver.FindElement(By.XPath("/html/body/div/div[2]/div[@id=" + bookingid + "]/div[7]/input")).Click();
                Thread.Sleep(2000);
            }

            var latest = response.GetLastBookingFirstanme();
            Assert.That(firstname, Is.Not.EqualTo(latest));
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }
    }
}
