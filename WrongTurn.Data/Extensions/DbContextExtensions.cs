using WrongTurn.Data.Context;
using WrongTurn.Data.Helpers;

namespace WrongTurn.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task InsertDefaultValues(this WrongTurnDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                var dbInitializer = new DbInitializer(context);
                await dbInitializer.InitializeAsync();
            }
        }
    }
}
