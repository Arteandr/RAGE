using Gamemode.Server.Handler.Events;
using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemode.Server.Core.Events
{
    class MiscEvents : Script
    {
        [ServerEvent(Event.Update)]
        public void Update()
        {
            EventsHandler.Instance.OnUpdate();
        }
    }
}
