namespace WrongTurn.StateManagement.Events
{
    public class StateChangedEventArgs : EventArgs
    {
        public PlayerState PlayerState { get; }

        public StateChangedEventArgs(PlayerState playerState)
        {
            PlayerState = playerState;
        }
    }
}
