using WrongTurn.StateManagement.Actions.Achievement;
using WrongTurn.StateManagement.Actions.Balance;
using WrongTurn.StateManagement.Exceptions;

namespace WrongTurn.StateManagement
{
    public static class Reducers
    {
        public static PlayerState BalanceReducer(PlayerState state, RebalancingAction action)
        {
            var sumOfChanges = action.SumChanges;
            var newBalance = state.Balance + sumOfChanges;
            if (newBalance < 0) throw new NotEnoughMoneyException();
            return new PlayerState(newBalance, state.Achievements);
        }

        public static PlayerState AchievementReducer(PlayerState state, AchievementUnlockAction action)
        {
            var currentAchievements = state.Achievements;
            var newAchievementId = action.AchievementId;
            if (currentAchievements.Contains(newAchievementId)) return state;
            var newAchievements = new List<string>(currentAchievements) { newAchievementId };
            return new PlayerState(state.Balance, newAchievements);
        }
    }
}
