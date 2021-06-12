using Gamemode.Server.Handler.Events;
using GTANetworkAPI;
using System;

namespace Gamemode.Server.Core.Events
{
    class ConnectionEvents : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            try
            {
                if (player is null)
                    return;

                EventsHandler.Instance.OnPlayerConnected(player);
            }catch(Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }
        }
    }
}
