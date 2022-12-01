using WrongTurn.Data.Context;
using WrongTurn.Data.Entities;
using WrongTurn.Data.Repositories;

namespace WrongTurn.Data.Helpers
{
    public class DbInitializer
    {
        private readonly WrongTurnDbContext _dbContext;

        public DbInitializer(WrongTurnDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            await InsertPlayers();
        }

        public async Task InsertPlayers()
        {
            var playerRepository = new DbPlayerRepository(_dbContext);

            var players = new List<Player>{
                new(),
                new() { Balance = 1000 }
            };

            foreach (var player in players)
            {
                await playerRepository.SaveAsync(player);
            }
        }
    }
}
