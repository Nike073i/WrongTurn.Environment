using WrongTurn.Data.Repositories;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Base;

namespace WrongTurn.API.Services
{
    public class PlayerStateService
    {
        private readonly DbPlayerRepository _playerRepository;

        public PlayerStateService(DbPlayerRepository playerRepository)
        {
            this._playerRepository = playerRepository;
        }

        public async Task<PlayerState> ApplyChanges(PlayerState currentState, IEnumerable<IPlayerAction> actions)
        {
            throw new NotImplementedException();
        }

        public async Task MarkAchievementAsUnlocked(Guid playerId, string achievementId)
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerState> GetPlayerState(Guid playerId)
        {
            throw new NotImplementedException();
        }
    }
}
