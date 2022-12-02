using WrongTurn.API.Exceptions;
using WrongTurn.Data.Entities;
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
            _playerRepository = playerRepository;
        }

        public async Task<PlayerState?> ApplyChanges(Guid playerId, PlayerState requestState, IEnumerable<IPlayerAction> actions)
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            if (player == null) throw new PlayerNotFoundException("Игрок с указанным Id не найден");
            var achievements = player.PlayerAchievements.Select(a => a.AchievementId);
            var storedState = new PlayerState(player.Balance, achievements);

            var correctState = RepeatActions(storedState, actions);
            await UpdatePlayer(correctState, player);
            return correctState.Equals(requestState) ? null : correctState;
        }

        private PlayerState RepeatActions(PlayerState currentState, IEnumerable<IPlayerAction> actions)
        {
            var store = new Store(currentState);
            foreach (var action in actions)
            {
                store.Dispatch(action);
            }
            return store.PlayerState;
        }

        private async Task UpdatePlayer(PlayerState correctState, Player player)
        {
            var correctBalance = correctState.Balance;
            var correctAchievements = correctState.Achievements;
            foreach (var achievement in player.PlayerAchievements)
            {
                if (correctAchievements.Contains(achievement.AchievementId))
                    achievement.IsConfirmed = true;
            }
            player.Balance = correctBalance;
            await _playerRepository.SaveAsync(player);
        }

        public async Task MarkAchievementAsUnlocked(Guid playerId, string achievementId)
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            if (player == null) throw new PlayerNotFoundException("Игрок с указанным Id не найден");
            var playerAchievements = player.PlayerAchievements;
            var isAchievementMarked = playerAchievements.Select(pa => pa.AchievementId).Any(id => id.Equals(achievementId));
            if (isAchievementMarked) return;
            var achievement = new PlayerAchievement(playerId, achievementId, date: DateTime.UtcNow, isConfirmed: false);
            playerAchievements.Add(achievement);
            await _playerRepository.SaveAsync(player);
        }

        public async Task<PlayerState?> GetPlayerState(Guid playerId)
        {
            var player = await _playerRepository.GetByIdAsync(playerId);
            if (player == null) return null;
            var achievements = player.PlayerAchievements.Select(a => a.AchievementId);
            var playerState = new PlayerState(player.Balance, achievements);
            return playerState;
        }
    }
}
