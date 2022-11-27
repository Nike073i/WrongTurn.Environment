namespace WrongTurn.Data.Entities
{
    public class Player : Entity
    {
        public decimal Balance { get; set; }
        public IEnumerable<PlayerAchievement> PlayerAchievements { get; protected set; }
    }
}
