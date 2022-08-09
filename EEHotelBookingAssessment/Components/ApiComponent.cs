using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Security.Cryptography.X509Certificates;

namespace EEHotelBookingAssessment.Components
{
    public class ApiComponent
    {
        public IRestResponse Get(String endpoint, IDictionary<string, string> headers = null)
        {
            return Process(Method.GET, endpoint,null, headers);
        }

        public IRestResponse Post(String endpoint, dynamic model, IDictionary<string, string> headers = null)
        {
            return Process(Method.POST, endpoint, model, headers);
        }

        public IRestResponse Delete(String endpoint, string model, IDictionary<string, string> headers = null)
        {
            return Process(Method.DELETE, endpoint, model, headers);
        }

        private IRestResponse Process(Method method , string endpoint, string model, IDictionary<string, string> headers = null, string contentType = null)
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest(method);

            if (headers != null) restRequest.AddHeaders(headers);

            restClient.BaseUrl = new Uri(endpoint);

            if (method != Method.GET)
            {
                restRequest.AddParameter(contentType, model, ParameterType.RequestBody);
            }

            var response = restClient.Execute(restRequest);

            return response;
        }
    }
}
