using Microsoft.Extensions.Configuration;
using System.IO;

namespace AkvelonAzureApi
{
    public class Config
    {
        public string Organization { get; set; }
        public string RepositoryId { get; set; }
        public string Project { get; set; }
        public string ApiVersion { get; set; }
        public string Token { get; set; }

        public Config()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            Organization = config["Organization"];
            RepositoryId = config["RepositoryId"];
            Project = config["Project"];
            ApiVersion = config["ApiVersion"];
            Token = config["Token"];
        }
    }
}
