using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEHotelBookingAssessment.Helpers
{
    public class NunitTestbase : WebdriverManager
    {
        [TearDown]
        public void TearDown()
        {
            try
            {
                CloseAllDrivers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
