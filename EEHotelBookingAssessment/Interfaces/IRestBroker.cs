using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace EEHotelBookingAssessment.Interfaces
{
    public interface IRestBroker
    {
        IRestResponse Get(string endpoint, bool useSecureTokenService = false, IDictionary<string, string> headers = null);
    }
}
