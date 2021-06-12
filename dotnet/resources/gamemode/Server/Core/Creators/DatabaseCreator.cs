using Gamemode.Server.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemode.Server.Core.Creators
{
    internal static class DatabaseCreator
    {
        internal static IServiceCollection WithDatabase(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddDbContext<AppDbContext>(ServiceLifetime.Singleton,ServiceLifetime.Transient);
        }
    }
}
