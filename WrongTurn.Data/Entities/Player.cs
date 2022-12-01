namespace WrongTurn.Data.Entities
{
    public class Player : Entity
    {
        public decimal Balance { get; set; }
        public List<PlayerAchievement> PlayerAchievements { get; set; }

        public Player()
        {
            Balance = 0;
            PlayerAchievements = new List<PlayerAchievement>();
        }
    }
}
