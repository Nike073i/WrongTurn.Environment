using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WrongTurn.API.Converters;
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

        [JsonConverter(typeof(PlayerActionConverter))]
        [Required]
        public IEnumerable<IPlayerAction> Actions { get; set; }
    }
}
