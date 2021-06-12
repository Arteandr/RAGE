
using Gamemode.Server.Database;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;

namespace Gamemode.Server.Core
{
    class Program : Script
    {
        public Program()
        {
            NapiInit(); // Initialize NAPI variables

            using (var dbContext = new AppDbContext())
            {
                var connection = (NpgsqlConnection)dbContext.Database.GetDbConnection();
                connection.Open();
                connection.ReloadTypes();
            }
        }

        private void NapiInit()
        {
            var date = DateTime.UtcNow;
            NAPI.World.SetTime(date.Hour, date.Minute, date.Second);
        }
    }
}
