namespace WrongTurn.StateManagement
{
    public class PlayerState
    {
        public decimal Balance { get; }
        public IEnumerable<string> Achievements { get; }

        public PlayerState(decimal balance, IEnumerable<string> achievements)
        {
            Balance = balance;
            Achievements = achievements;
        }

        public static PlayerState NewPlayerState()
        {
            return new PlayerState(0, Enumerable.Empty<string>());
        }

        public override bool Equals(object? obj)
        {
            return (obj is PlayerState other) && Equals(other);
        }

        public bool Equals(PlayerState other)
        {
            if (other == null) return false;
            return Balance == other.Balance && Achievements.SequenceEqual(other.Achievements);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Balance, Achievements);
        }
    }
}
