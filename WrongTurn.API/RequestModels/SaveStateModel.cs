using System.ComponentModel.DataAnnotations;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Base;

namespace WrongTurn.API.RequestModels
{
    public class SaveStateModel
    {
        [Required]
        public Guid PlayerId { get; set; }

        [Required]
        public PlayerState PlayerState { get; set; }

        [Required]
        public IEnumerable<PlayerAction> Actions { get; set; }
    }
}
