namespace WrongTurn.Data.Entities
{
    public class PlayerAchievement : Entity
    {
        public Guid PlayerId { get; set; }
        public string AchievementId { get; set; }
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; }

        public PlayerAchievement(Guid playerId, string achievementId, DateTime date, bool isConfirmed)
        {
            PlayerId = playerId;
            AchievementId = achievementId;
            Date = date;
            IsConfirmed = isConfirmed;
        }
    }
}
