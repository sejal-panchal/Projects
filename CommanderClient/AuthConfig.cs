using System;
using System.IO;
using System.Globalization;
using Microsoft.Extensions.Configuration;
namespace CommanderClient
{
    public class AuthConfig
    {
        public string InstanceId { get; set; }
        public string ResourceId { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string Authrority  { 
            get{ return string.Format(CultureInfo.InstalledUICulture,InstanceId,TenantId);}
            
         }

         public string  ClientSecret { get; set; }
         public string BaseAddress { get; set; }

         public static AuthConfig ReadJsonFromFile(string path)
         {
             IConfiguration Configuration;

             var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path);

            Configuration = builder.Build();
            return Configuration.Get<AuthConfig>();

         }
    }
}