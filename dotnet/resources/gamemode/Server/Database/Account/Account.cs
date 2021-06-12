using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemode.Server.Database.Account
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; }
        public string Password { get; set; }
        public string SocialClubName { get; set; }
        public ulong SocialClubId { get; set; }
        public uint Donation { get; set; }
    }
}
