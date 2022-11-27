using WrongTurn.Data.Context;
using WrongTurn.Data.Entities;

namespace WrongTurn.Data.Repositories
{
    public class DbPlayerRepository : DbRepository<Player>
    {
        public DbPlayerRepository(WrongTurnDbContext context) : base(context) { }
    }
}
