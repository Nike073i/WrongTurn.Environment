using Microsoft.EntityFrameworkCore;
using WrongTurn.Data.Context.Configurations;

namespace WrongTurn.Data.Context
{
    public class WrongTurnDbContext : DbContext
    {
        public WrongTurnDbContext(DbContextOptions<WrongTurnDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlayerAchievementConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        }
    }
}
