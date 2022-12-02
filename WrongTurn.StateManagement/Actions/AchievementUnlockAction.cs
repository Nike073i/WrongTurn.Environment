using WrongTurn.StateManagement.Actions.Base;

namespace WrongTurn.StateManagement.Actions.Achievement
{
    public class AchievementUnlockAction : PlayerAction
    {
        public string AchievementId { get; }
        public AchievementUnlockAction(string achievementId)
        {
            AchievementId = achievementId;
        }

        public override PlayerState Handle(PlayerState currentState)
        {
            return Reducers.AchievementReducer(currentState, this);
        }
    }
}
