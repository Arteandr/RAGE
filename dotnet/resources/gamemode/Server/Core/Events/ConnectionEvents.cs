using GTANetworkAPI;


namespace Gamemode.Server.Core.Events
{
    class ConnectionEvents : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void PlayerConnected(Player player)
        {

        }
    }
}
