using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;  
using EEHotelBookingAssessment.Components;
using EEHotelBookingAssessment.Helpers;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System.Text.Json;
using EEHotelBookingAssessment.Static;

namespace EEHotelBookingAssessment.TestLibrary
{
    public  class APITestHelpers : NunitTestbase
    {
        public List<int> allBookingIds = new();

        [Test]
        public void GetClientDetails()
        {
            test = null;
            test = extent.CreateTest("T001").Info("GetClientDetails");
            test.Log(Status.Pass, "Test Pass");

            var response = new ApiComponent();
            var p = response.Get(ConfigData.BookingsAPIUrl, false, null);
            Assert.Multiple(() =>
            {
                Assert.That(p.StatusCode.ToString(), Is.EqualTo("OK"));
                Assert.That(p.ResponseStatus.ToString(), Is.EqualTo("Completed"));
                test.Log(Status.Pass, "Test Pass");
            });
        }

        public string GetLastBookingID()
        {
            var apicomponent = new ApiComponent();
            var response = apicomponent.Get(ConfigData.BookingsAPIUrl, false, null);
            var stripResponse = JsonConvert.DeserializeObject(response.Content);

            var allbookings = JsonDocument.Parse(stripResponse.ToString());

            for (int i = 0; i < allbookings.RootElement.GetArrayLength(); i++)
            {
                var singleBookingId = allbookings.RootElement[i];
                var bookingId = singleBookingId.GetProperty("bookingid");
                allBookingIds.Add(int.Parse(bookingId.ToString()));
            }

            var lastid = allBookingIds.Last().ToString();
            return lastid;
        }

        public string GetLastBookingFirstanme()
        {
            var bookingid = GetLastBookingID();
            var response = new ApiComponent();
            var headers = new Dictionary<string, string>();
            {
                headers.Add("Accept", "*/*");
            };

            var p = response.Get(ConfigData.BookingsAPIUrl + bookingid, false, headers);
            var te = JsonConvert.DeserializeObject(p.Content);
            var allbookings = JsonDocument.Parse(te.ToString());
            var singleBookingId = allbookings.RootElement;
            var firstname = singleBookingId.GetProperty("firstname").ToString();
            return firstname;
        }
    }
}
