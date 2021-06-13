using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemode.Server.Handler.Events
{
    public class EventsHandler
    {
#nullable enable
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public static EventsHandler Instance { get; private set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
       
        private int _hourCounter;
        private int _minuteCounter;
        private int _secondCounter;

        public delegate void CounterDelegate(int counter);
        public delegate void IncomingConnectionDelegate(string ip, string serial, string socialClubName, ulong socialClubId);
        public delegate void PlayerDelegate(Player player);
        public delegate void ErrorDelegate(Exception ex, Player? source = null);
        public delegate void ErrorMessageDelegate(string info, string? stackTrace = null, string? exceptionType = null, Player? source = null);
        public delegate void EmptyDelegate();
        
        public event ErrorDelegate? Error;
        public event EmptyDelegate? LoadedServerBans;   
        public event PlayerDelegate? PlayerConnected;
        public event PlayerDelegate? PlayerDisconnected;

        public event CounterDelegate? Hour;
        public event CounterDelegate? Minute;
        public event CounterDelegate? Second;

        public event EmptyDelegate? Update;


        public EventsHandler()
        {
            Console.WriteLine("test");
            Instance = this;
        }

        public void OnPlayerConnected(Player player)
        {
            try
            {
                PlayerConnected?.Invoke(player);

            }catch(Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }
        }
        internal void OnHour()
        {
            try
            {
                Hour?.Invoke(++_hourCounter);
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex);
            }
        }

        internal void OnMinute()
        {
            try
            {
                Minute?.Invoke(++_minuteCounter);
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex);
            }
        }
        internal void OnSecond()
        {
            try
            {
                Second?.Invoke(++_secondCounter);
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex);
            }
        }
        public void OnUpdate()
        {
            try
            {
                Update?.Invoke();
            }
            catch (Exception ex) { Console.WriteLine("[ERROR] " + ex.Message); }
        }
    }
}
