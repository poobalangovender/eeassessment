using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEHotelBookingAssessment.Helpers;
using OpenQA.Selenium;

namespace EEHotelBookingAssessment.TestLibrary
{
    public class HotelBookingPositiveTestcases : NunitTestbase
    {
        [Test]
        public void LoadHotelBookingForm()
        {
            InitBrowser("Chrome");
            LoadWebsite("http://hotel-test.equalexperts.io/");
            Thread.Sleep(2000);
            TakeScreenshot("C:\\Screenshots\\hello.png");
        }

        [Test]
        public void AddClientDetails()
        {
            InitBrowser("Chrome");
            LoadWebsite("http://hotel-test.equalexperts.io/");
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("firstname")).SendKeys("TesterCPT");
            Driver.FindElement(By.Id("lastname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys("TesterSurname");
            Driver.FindElement(By.Id("totalprice")).Clear();
            Driver.FindElement(By.Id("totalprice")).SendKeys("299.99");
            Driver.FindElement(By.Id("depositpaid")).SendKeys("false");
            Driver.FindElement(By.Id("depositpaid")).SendKeys("false");
            Driver.FindElement(By.Id("checkin")).SendKeys("2022-08-30"); 
            Driver.FindElement(By.Id("checkout")).SendKeys("2022-09-01");
            Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
            //searchAndClick("TesterCPT");
            TakeScreenshot("C:\\Screenshots\\hello.png");
            Thread.Sleep(2000);
            //Need to add an assert here - bring the api call in to check if the Details was added correctly
            //Add comments to all the code
        }

        public void searchAndClick(string name)
        {
            IList<IWebElement> tableRow = Driver.FindElements(By.Id("bookings"));
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Equals(name))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void DeleteClientBookingDetails()
        {
            var apitestinstance = new APITests();
            var bookingid = apitestinstance.LastBookingID();

            InitBrowser("Chrome");
            LoadWebsite("http://hotel-test.equalexperts.io/");
            Driver.FindElement(By.XPath("/html/body/div/div[2]/div[@id=" + bookingid + "]/div[7]/input")).Click();
            Thread.Sleep(5000);
        }
    }
}
