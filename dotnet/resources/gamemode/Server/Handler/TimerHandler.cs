
using Gamemode.Server.Data.Utils;
using Gamemode.Server.Handler.Events;
using Gamemode.Shared.Core;
using System;


namespace Gamemode.Server.Handler
{
    public class TimerHandler
    {
        private readonly EventsHandler _eventsHandler;

        public TimerHandler(EventsHandler eventsHandler)
        {
            _eventsHandler = eventsHandler;

            GamemodeTimer.Init(ex => Console.WriteLine(ex.Message), () => Environment.TickCount);

            _eventsHandler.Update += GamemodeTimer.OnUpdateFunc;

            _ = new GamemodeTimer(OnHour, 60 * 1000, 1);
            _ = new GamemodeTimer(OnMinute, Utils.GetMsToNextMinute(), 1);
            _ = new GamemodeTimer(OnSecond, Utils.GetMsToNextSecond(), 1);
        }

        private void OnHour()
        {
            _ = new GamemodeTimer(OnHour, Utils.GetMsToNextHour(), 1);
            _eventsHandler.OnHour();
        }

        private void OnMinute()
        {
            _ = new GamemodeTimer(OnMinute, Utils.GetMsToNextMinute(), 1);
            _eventsHandler.OnMinute();
        }

        private void OnSecond()
        {
            _ = new GamemodeTimer(OnSecond, Utils.GetMsToNextSecond(), 1);
            _eventsHandler.OnSecond();
        }
    }
}
