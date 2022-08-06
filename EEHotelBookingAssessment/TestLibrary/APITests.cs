using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEHotelBookingAssessment.Components;

namespace EEHotelBookingAssessment.TestLibrary
{
    public  class APITests : Testbase
    {
        [Test]
        public void GetClientDetails()
        {
            var response = new MyApiComponent();
            var p = response.Get("http://hotel-test.equalexperts.io/", false, null);
            Assert.That(p.StatusCode.ToString(), Is.EqualTo("OK"));
            Assert.That(p.ResponseStatus.ToString(), Is.EqualTo("Completed"));
        }
    }
}
