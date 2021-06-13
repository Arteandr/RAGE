using Gamemode.Server.Handler;
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
                .WithPlayers()
                .WithMisc();
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

        private static IServiceCollection WithMisc(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<TimerHandler>();
        }
    }
}
