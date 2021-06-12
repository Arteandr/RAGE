using Gamemode.Server.Handler.Events;
using Gamemode.Server.Handler.PlayerHandlers;
using Microsoft.Extensions.DependencyInjection;


namespace Gamemode.Server.Core.Creators
{
    internal static class Handler
    {
        public static IServiceCollection WithHandlers(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .WithEvents()
                .WithPlayers();
        }

        private static IServiceCollection WithPlayers(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ConnectedHandler>();
        }
        
        private static IServiceCollection WithEvents(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<EventsHandler>();
        }
    }
}
