using WrongTurn.StateManagement.Actions.Base;

namespace WrongTurn.StateManagement.Actions.Balance
{
    public class RebalancingAction : IPlayerAction
    {
        public decimal SumChanges { get; }
        public RebalancingAction(decimal sumChanges)
        {
            SumChanges = sumChanges;
        }

        public PlayerState Handle(PlayerState currentState)
        {
            return Reducers.BalanceReducer(currentState, this);
        }
    }
}
