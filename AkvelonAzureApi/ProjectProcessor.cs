using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace AkvelonAzureApi
{
    public class ProjectProcessor
    {
        private readonly Config _config;

        public ProjectProcessor(Config config)
        {
            _config = config;
        }

        public Project GetProjectData()
        {
            var uri = new Uri($"https://dev.azure.com/{_config.Organization}/{_config.Project}/_apis/git/repositories/{_config.RepositoryId}?api-version={_config.ApiVersion}");
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Authorization, $"Basic {_config.Token}");
            var data = client.DownloadString(uri);
            var jsonData = JObject.Parse(data)["project"].ToString();
            return JsonConvert.DeserializeObject<Project>(jsonData);
        }

        public void DisplayProjectInfo(Project project)
        {
            var props = project.GetPropsVelues();
            foreach (var p in props)
            {
                Console.WriteLine($"{p.Key}: {p.Value}");
            }
        }
    }
}
