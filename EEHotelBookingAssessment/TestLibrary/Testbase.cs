using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEHotelBookingAssessment.Components;

namespace EEHotelBookingAssessment.TestLibrary
{
    public class Testbase
    {
        public MyApiComponent ApiComponent;

        public void Init()
        {
            ApiComponent = new MyApiComponent();
        }

        [SetUp]
        public void SetUp()
        {
            if (ApiComponent == null)
            {
                Init();
            }
        }
    }
}
