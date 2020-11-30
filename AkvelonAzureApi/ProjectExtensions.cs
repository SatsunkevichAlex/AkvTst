using System.Collections.Generic;
using System.Reflection;

namespace AkvelonAzureApi
{
    public static class ProjectExtensions
    {
        public static IDictionary<string, string> GetPropsVelues(this Project project)
        {
            var type = project.GetType();
            var props = new List<PropertyInfo>(type.GetProperties());

            var result = new Dictionary<string, string>();
            foreach(var p in props)
            {
                result.Add(
                    p.Name,
                    p.GetValue(project, null).ToString()
               );
            }

            return result;
        }
    }
}
