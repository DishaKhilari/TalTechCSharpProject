using Microsoft.Extensions.Configuration;

namespace TalTechWebUIAutomation.Support
{
    internal static class TestConfiguration
    {
        private static readonly IConfiguration Configuration;

        static TestConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

        }

        public static string GetSectionAndValue(string sectionName,string value)
        {
            return Configuration.GetSection(sectionName)[value];
        }
    }
}
