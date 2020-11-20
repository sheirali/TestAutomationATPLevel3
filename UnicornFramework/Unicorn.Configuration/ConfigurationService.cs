using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Unicorn
{
    public class ConfigurationService
    {
        private static readonly IConfigurationRoot s_configurationRoot;

        static ConfigurationService()
        {
            s_configurationRoot = InitializeConfiguration();
        }

        private static IConfigurationRoot InitializeConfiguration()
        {
            var filesinExeDir = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var settingsFile = filesinExeDir.FirstOrDefault(x => x.Contains("testFrameworkSettings") && x.EndsWith("json", StringComparison.InvariantCultureIgnoreCase)).ToString();

            var builder = new ConfigurationBuilder();
            if (File.Exists(settingsFile))
            {
                builder.AddJsonFile(settingsFile, optional: false, reloadOnChange: true);
            }

            return builder.Build();
        }

        public static TSection GetSection<TSection>()
               where TSection : class, new()
        {
            string sectionName = typeof(TSection).Name.MakeFirstLetterToLower();
            return s_configurationRoot.GetSection(sectionName).Get<TSection>();
        }
    }
}
