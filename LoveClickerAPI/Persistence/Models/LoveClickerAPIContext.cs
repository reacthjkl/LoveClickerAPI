using Microsoft.EntityFrameworkCore;

namespace LoveClickerAPI.Persistence.Models
{
    public class LoveClickerAPIContext : DbContext
    {
        public LoveClickerAPIContext(DbContextOptions<LoveClickerAPIContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSecret> UserSecrets { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
    }
}