
using GTANetworkAPI;

namespace Gamemode.Server.Core
{
    class Program : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Util.ConsoleOutput("[SUCCESS] Server started");
        }
    }
}
