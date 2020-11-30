namespace AkvelonAzureApi
{
    class Program
    {
        static void Main()
        {
            var config = new Config();
            var processor = new ProjectProcessor(config);
            var project = processor.GetProjectData();
            processor.DisplayProjectInfo(project);
        }
    }
}
