using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoUpdater.Helpers
{
    public class ConfigHelper
    {
        public IConfiguration Configuration { get; }
        public static ConfigHelper Instance { get; private set; } = new ConfigHelper();
        private ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            Configuration.Bind(this);
        }

        public string AllowedHosts { get; set; }
        public string EkasutFilePath { get; set; }
        public string DbsyncFilePath { get; set; }
        public string ListenUrl { get; set; } = "http://0.0.0.0:5253";
    }

}
