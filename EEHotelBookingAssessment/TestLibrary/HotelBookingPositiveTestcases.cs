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
            Thread.Sleep(5000);
        }

        [Test]
        public void AddClientDetails()
        {
            InitBrowser("Chrome");
            LoadWebsite("http://hotel-test.equalexperts.io/");
            Driver.FindElement(By.Id("firstname")).Clear();
            Driver.FindElement(By.Id("firstname")).SendKeys("Poobalan");
            Driver.FindElement(By.Id("lastname")).Clear();
            Driver.FindElement(By.Id("lastname")).SendKeys("Govender");
            Driver.FindElement(By.Id("totalprice")).Clear();
            Driver.FindElement(By.Id("totalprice")).SendKeys("200");
            Driver.FindElement(By.Id("depositpaid")).SendKeys("false");
            Driver.FindElement(By.Id("depositpaid")).SendKeys("false");
            Driver.FindElement(By.Id("checkin")).SendKeys("2022-08-30"); 
            Driver.FindElement(By.Id("checkout")).SendKeys("2022-09-01");
            Driver.FindElement(By.XPath("//*[@id='form']/div/div[7]/input")).Click();
            searchAndClick("Test");
            Thread.Sleep(2000);
        }

        public void searchAndClick(string name)
        {
            IList<IWebElement> tableRow = Driver.FindElements(By.Id("bookings"));
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Equals(name))
                {
                    Assert.Pass();
                    //Driver.FindElement(By.XPath("//td[text()='" + name + "']/following-sibling::td[contains(@class,'text-center')]/button")).Click();
                }
            }
        }

        [Test]
        public void ViewClient()
        {
            InitBrowser("Chrome");
            LoadWebsite("http://hotel-test.equalexperts.io/");
            Thread.Sleep(8000);
        }

        [Test]
        public void DeleteClient()
        {
            InitBrowser("Chrome");
            LoadWebsite("http://hotel-test.equalexperts.io/");
            Thread.Sleep(8000);
        }

        [Test]
        public void AlignmentAndSizingScreenshot()
        {
            InitBrowser("Chrome");
            LoadWebsite("http://hotel-test.equalexperts.io/");
            Thread.Sleep(8000);
        }
    }
}
