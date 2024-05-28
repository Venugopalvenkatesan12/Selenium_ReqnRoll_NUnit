using Microsoft.Extensions.Configuration;

namespace SeleniumReqnRollNunit.Helpers
{
    public class JsonHelper
    {
       public static string? GetConfigValue(string xPath)
       {
            var jsonPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Configurations\\appsettings.json");
            var config = new ConfigurationBuilder().AddJsonFile(jsonPath).Build();
            return config[xPath];            
       }
    }
}
