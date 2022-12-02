using WrongTurn.StateManagement.Actions.Base;
using WrongTurn.StateManagement.Events;

namespace WrongTurn.StateManagement
{
    public class Store
    {
        public PlayerState PlayerState { get; private set; }
        public event EventHandler<StateChangedEventArgs>? StateChanged;

        public Store(PlayerState playerState)
        {
            PlayerState = playerState;
        }

        public void Dispatch(PlayerAction action)
        {
            OnStateChanged(action.Handle(PlayerState));
        }

        private void OnStateChanged(PlayerState newState)
        {
            if (PlayerState == newState) return;
            PlayerState = newState;
            var temp = Volatile.Read(ref StateChanged);
            if (temp != null)
            {
                var args = new StateChangedEventArgs(newState);
                temp(this, args);
            }
        }
    }
}
