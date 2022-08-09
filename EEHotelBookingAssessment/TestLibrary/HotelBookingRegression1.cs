using EEHotelBookingAssessment.Helpers;
using OpenQA.Selenium;
using EEHotelBookingAssessment.Static;
using AventStack.ExtentReports;

namespace EEHotelBookingAssessment.TestLibrary
{
    public class HotelBookingRegression1 : NunitTestbase
    {
        [TestCase("HotelBookingForm")]
        public void LoadHotelBookingForm(string screenshotname)
        {
            test = null;
            test = extent.CreateTest("LoadHotelBookingForm").Info("Hotel Booking Form");

            InitBrowser("Chrome");
            LoadWebsite(ConfigData.HotelBookingWebsite);
            Thread.Sleep(1500);
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            test.Log(Status.Pass, "Test Pass");
        }

        [TestCase("AddClientDetails", "TesterCPT", "TesterSurname", "299.99", "false", "2022-09-01")]
        public void AddClientDetails(string screenshotname, string firstname, string lastname, string price, string depositpaid, string checkout )
        {
            try
            {
                test = null;
                test = extent.CreateTest("AddClientDetails").Info("Add Client Details");

                InitBrowser("Chrome");
                LoadWebsite(ConfigData.HotelBookingWebsite);
                Driver.FindElement(By.Id("firstname")).Clear();
                Driver.FindElement(By.Id("firstname")).SendKeys(firstname);
                Driver.FindElement(By.Id("lastname")).Clear();
                Driver.FindElement(By.Id("lastname")).SendKeys(lastname);
                Driver.FindElement(By.Id("totalprice")).Clear();
                Driver.FindElement(By.Id("totalprice")).SendKeys(price);
                Driver.FindElement(By.Id("depositpaid")).SendKeys(depositpaid);
                Driver.FindElement(By.Id("checkin")).SendKeys(DateTime.Now.ToString("yyyy-MM-dd"));
                Driver.FindElement(By.Id("checkout")).SendKeys(DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"));
                Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
                Thread.Sleep(1500);
                var lastbookingfirstname = response.GetLastBookingFirstanme();
                Assert.That(lastbookingfirstname, Is.EqualTo(firstname));
                test.Log(Status.Pass, "Test Pass");
                TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            }
            catch(Exception ex)
            {
                test.Log(Status.Fail, "Failed, Please investigate.");
                Assert.Fail(ex.Message);
            }

        }

        [TestCase("DeleteClientDetails","TesterCPT")]
        public void DeleteClientBookingDetails(string screenshotname, string firstname)
        {
            test = null;
            test = extent.CreateTest("DeleteClientBookingDetails").Info("Delete Client Details");

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
            test.Log(Status.Pass, "Test Pass");
            TakeScreenshot(ConfigData.Screenshotdirectory + screenshotname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        }
    }
}
