
using Gamemode.Server.Core.Creators;
using Gamemode.Server.Data.Utils;
using Gamemode.Server.Database;
using Gamemode.Server.Handler.Events;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;

namespace Gamemode.Server.Core
{
    class Program : Script
    {
        private readonly CustomServiceProvider _serviceProvider;

        public Program()
        {
            NapiInit();

            _serviceProvider = ServiceProviderCreator.Create();

            using(var dbContext = _serviceProvider.GetRequiredService<AppDbContext>())
            {
                //    dbContext.Database.Migrate();
                var connection = (NpgsqlConnection)dbContext.Database.GetDbConnection();
                connection.Open();
                connection.ReloadTypes();
            }


            _serviceProvider.InitAllSingletons();

            var eventsHandler = _serviceProvider.GetRequiredService<EventsHandler>();
            eventsHandler.Minute += (_) =>
            {
                var date = DateTime.UtcNow;
                NAPI.World.SetTime(date.Hour, date.Minute, date.Second);
            };
        }

        private void NapiInit()
        {
            var date = DateTime.UtcNow;
            NAPI.World.SetTime(date.Hour, date.Minute, date.Second);
        }
    }
}
