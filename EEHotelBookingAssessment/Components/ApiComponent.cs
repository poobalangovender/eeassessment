//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net.Http.Headers;
//using System.Net.Http;
//using System.Security.Authentication;

//namespace EEHotelBookingAssessment.Components
//{
//    public class ApiComponent
//    {
//        public async Task<HttpResponseMessage> SendAsync(HttpPacket httpPacket, CancellationToken cancellationToken = default)
//        {
//            return await ProcessAsync(httpPacket, cancellationToken)
//        }

//        private async Task<HttpResponseMessage> ProcessAsync(HttpPacket httpPacket, CancellationToken cancellationToken = default)
//        {
//            try
//            {
//                var handler = new HttpClientHandler();
//                using var httpClient = new HttpClient(handler);

//                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors => { return true; };

//                handler.SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;


//                )
//            }
//        }
//    }
//}
