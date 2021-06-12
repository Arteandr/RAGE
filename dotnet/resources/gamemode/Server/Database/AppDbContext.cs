using Gamemode.Server.Handler.Server;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gamemode.Server.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(EnvironmentConfigHandler.ConnectionString);
        }
    }
}
