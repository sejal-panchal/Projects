using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace CommanderClient
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Making call...");
           // ServicePointManager.ServerCertificateValidationCallback += SelfSignedForLocalhost;
            
            RunAsync().GetAwaiter().GetResult();
            
        }
    // private static bool SelfSignedForLocalhost(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //     {
    //         if (sslPolicyErrors == SslPolicyErrors.None)
    //         {
    //             return true;
    //         }

    //         // For HTTPS requests to this specific host, we expect this specific certificate.
    //         // In practice, you'd want this to be configurable and allow for multiple certificates per host, to enable
    //         // seamless certificate rotations.
    //         return sender is HttpWebRequest httpWebRequest
    //                 && httpWebRequest.RequestUri.Host == "localhost"
    //                 && certificate is X509Certificate2 x509Certificate2
    //                 && X509Certificate2.Thumbprint == "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
    //                 && sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors;
    //     }
        private static async Task RunAsync()
        {
            AuthConfig config= AuthConfig.ReadJsonFromFile("appsettings.json");
            IConfidentialClientApplication app;
            app=ConfidentialClientApplicationBuilder.Create(config.ClientId)
                .WithClientSecret(config.ClientSecret)
                .WithAuthority(new Uri(config.Authrority))
                .Build();

            string[] ResourceIds=new string[] {config.ResourceId};

            AuthenticationResult result=null;

            try
            {
                result= await app.AcquireTokenForClient(ResourceIds).ExecuteAsync();
                Console.ForegroundColor=ConsoleColor.Green;
                System.Console.WriteLine("Token Aquired \n");
                System.Console.WriteLine(result.AccessToken);
                Console.ResetColor();
            }catch(Exception ex)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                System.Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            if(!string.IsNullOrEmpty(result.AccessToken))
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                var httpClient= new HttpClient(httpClientHandler);
                var defaultRequestHeaders= httpClient.DefaultRequestHeaders;

                if(defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m=>m.MediaType=="application/json"))
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                
                
                defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",result.AccessToken);

                HttpResponseMessage responseMessage= await httpClient.GetAsync(config.BaseAddress);
                if(responseMessage.IsSuccessStatusCode)
                {
                    Console.ForegroundColor=ConsoleColor.Green;
                    string json= await responseMessage.Content.ReadAsStringAsync();
                    System.Console.WriteLine(json);
                }else
                {
                    Console.ForegroundColor=ConsoleColor.Red;
                    System.Console.WriteLine($"Failed to call API: {responseMessage.StatusCode}");
                    string content= await responseMessage.Content.ReadAsStringAsync();
                    System.Console.WriteLine($"Content: {content}");
                }
                Console.ResetColor();
            }
        }
    }
}
