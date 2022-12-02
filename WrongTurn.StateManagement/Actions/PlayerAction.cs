namespace WrongTurn.StateManagement.Actions.Base
{
    public class PlayerAction
    {
        public virtual PlayerState Handle(PlayerState currentState) { return currentState; }
    }
}
