using EEHotelBookingAssessment.Components;
using EEHotelBookingAssessment.Helpers;
using Newtonsoft.Json;
using System.Text.Json;

namespace EEHotelBookingAssessment.TestLibrary
{
    public  class APITests : NunitTestbase
    {
        public List<int> allBookingIds = new();

        [Test]
        public void GetClientDetails()
        {
            var response = new ApiComponent();
            var p = response.Get("http://hotel-test.equalexperts.io/", false, null);
            Assert.Multiple(() =>
            {
                Assert.That(p.StatusCode.ToString(), Is.EqualTo("OK"));
                Assert.That(p.ResponseStatus.ToString(), Is.EqualTo("Completed"));
            });
        }

        public string LastBookingID()
        {
            var apicomponent = new ApiComponent();
            var response = apicomponent.Get("http://hotel-test.equalexperts.io/booking/", false, null);
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

        [Test]
        public void LastBookingFirstanme()
        {
            var bookingid = LastBookingID();
            var response = new ApiComponent();
            var headers = new Dictionary<string, string>();
            {
                headers.Add("Accept", "*/*");
            };

            var p = response.Get("http://hotel-test.equalexperts.io/booking/" + bookingid, false, headers);
            var te = JsonConvert.DeserializeObject(p.Content);
            var allbookings = JsonDocument.Parse(te.ToString());
            var singleBookingId = allbookings.RootElement;
            var firstname = singleBookingId.GetProperty("firstname").ToString();
            Assert.That(firstname, Is.EqualTo("TesterCPT"));
        }
    }
}
