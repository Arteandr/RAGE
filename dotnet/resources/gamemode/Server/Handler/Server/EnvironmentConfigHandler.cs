using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemode.Server.Handler.Server
{
    public static class EnvironmentConfigHandler
    {
        public static string ConnectionString
        {
            get
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("AppSettings.json");
                var config = builder.Build();
                return config.GetConnectionString("Main");
            }
        }
    }
}
