using Gamemode.Server.Handler.Events;
using Gamemode.Server.Handler.Extensions;
using GTANetworkAPI;
using System;

namespace Gamemode.Server.Handler.PlayerHandlers
{
    public class ConnectedHandler
    {
        private readonly EventsHandler _eventsHandler;
        public ConnectedHandler(EventsHandler eventsHandler)
        {
            _eventsHandler = eventsHandler;

            _eventsHandler.PlayerConnected += PlayerConnected;
        }

        private void PlayerConnected(Player player)
        {
            try
            {
                if (player is null)
                    return;

                Console.WriteLine($"Player connected | Name: {player.Name} | ScName: {player.SocialClubName} | ScId: {player.SocialClubId} | IP: {player.Address}");
                SpawnPlayerInWorld(player);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }
        }

        private void SpawnPlayerInWorld(Player player)
        {
            NAPI.Task.RunSafe(() =>
            {
                player.Position = new Vector3(0, 0, 1000).Around(10);
            });
        }
    }
}
