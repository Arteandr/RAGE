using Gamemode.Server.Handler.Events;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }
        }
    }
}
