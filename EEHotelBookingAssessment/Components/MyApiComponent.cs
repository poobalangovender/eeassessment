using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using EEHotelBookingAssessment.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace EEHotelBookingAssessment.Components
{
    public class MyApiComponent
    {
        public IRestResponse Get(String endpoint, bool useSecureTokenService = false, IDictionary<string, string> headers = null)
        {
            return Process(Method.GET, endpoint, null, useSecureTokenService, headers);
        }

        public IRestResponse Post(String endpoint,dynamic model, bool useSecureTokenService = false, IDictionary<string, string> headers = null)
        {
            return Process(Method.POST, endpoint, model, useSecureTokenService, headers);
        }

        //public IRestResponse Post(String endpoint, dynamic model,X509Certificate2Collection certificates, string contentType = null, IDictionary<string, string> headers = null)
        //{
        //    return Process(Method.POST, endpoint, model, certificates, contentType, headers);
        //}

        public IRestResponse Delete(String endpoint, string model, bool useSecureTokenService = false, IDictionary<string, string> headers = null)
        {
            return Process(Method.DELETE, endpoint, model, useSecureTokenService, headers);
        }

        private IRestResponse Process(Method method , string endpoint, string model, bool useSecureTokenService = false, IDictionary<string, string> headers = null, string contentType = null, X509Certificate2Collection certificates = null)
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest(method);

            if (headers != null) restRequest.AddHeaders(headers);

            if (certificates != null) restClient.ClientCertificates = certificates;

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
