namespace WrongTurn.StateManagement.Actions.Base
{
    public interface IPlayerAction
    {
        PlayerState Handle(PlayerState currentState);
    }
}
