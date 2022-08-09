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
        public List<int> Getbookings = new();

        [Test]
        public void GetClientDetails()
        {
            test = null;
            test = extent.CreateTest("API_GetClientDetails").Info("API Test " + ConfigData.BookingsAPIUrl);

            var response = new ApiComponent();
            var p = response.Get(ConfigData.BookingsAPIUrl, null);
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
            var response = apicomponent.Get(ConfigData.BookingsAPIUrl, null);
            var stripResponse = JsonConvert.DeserializeObject(response.Content);

            var allbookings = JsonDocument.Parse(stripResponse.ToString());

            for (int i = 0; i < allbookings.RootElement.GetArrayLength(); i++)
            {
                var bookingidroot = allbookings.RootElement[i];
                var bookingId = bookingidroot.GetProperty("bookingid");
                Getbookings.Add(int.Parse(bookingId.ToString()));
            }

            var lastid = Getbookings.Last().ToString();
            return lastid;
        }

        public string GetLastBookingFirstanme()
        {
            var bookingid = GetLastBookingID();
            var apicomponent = new ApiComponent();
            var headers = new Dictionary<string, string>();
            {
                headers.Add("Accept", "*/*");
            };

            var p = apicomponent.Get(ConfigData.BookingsAPIUrl + bookingid, headers);
            var split = JsonConvert.DeserializeObject(p.Content);
            var allbookings = JsonDocument.Parse(split.ToString());
            var singleBookingId = allbookings.RootElement;
            var firstname = singleBookingId.GetProperty("firstname").ToString();
            return firstname;
        }
    }
}
