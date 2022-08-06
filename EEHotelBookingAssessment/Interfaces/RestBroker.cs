using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Security.Cryptography.X509Certificates;

namespace EEHotelBookingAssessment.Interfaces
{
    public class RestBroker : IRestBroker
    {
        public IRestResponse Get(string endpoint, bool useSecureTokenService = false, IDictionary<string, string> headers = null)
        {
            return Process(Method.GET, endpoint, null, useSecureTokenService, headers);
        }

        private IRestResponse Process(Method method, string endpoint, string model, bool useSecureTokenService = false,
            IDictionary<string, string> headers = null, string contentType = null, X509Certificate2Collection certificates = null)
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest(method);

            if (headers != null)
                restRequest.AddHeaders(headers);

            //if (certificates != null)
            //    RestClient.ClientCertificates = certificates;

            restClient.BaseUrl = new Uri(endpoint);

            if(method != Method.GET)
            {
                restRequest.AddParameter(contentType, model, ParameterType.RequestBody);
            }

            var response = restClient.Execute(restRequest);

            return response;
        }
    }
}
