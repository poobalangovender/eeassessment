using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEHotelBookingAssessment.Static
{
    public class ConfigData
    {
        public static string HotelBookingWebsite = "http://hotel-test.equalexperts.io/";
        public static string Screenshotdirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Screenshots/";
        public static string BookingsAPIUrl = "http://hotel-test.equalexperts.io/booking/";
    }
}
