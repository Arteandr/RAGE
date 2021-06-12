using Gamemode.Server.Data.Utils;
using Microsoft.Extensions.DependencyInjection;


namespace Gamemode.Server.Core.Creators
{
    internal static class ServiceProviderCreator
    {
        public static CustomServiceProvider Create()
        {
            var serviceCollection = new ServiceCollection()
                .WithDatabase()
                .WithHandlers();

            var provider = new CustomServiceProvider(serviceCollection);
            return provider;
        }
    }
}
