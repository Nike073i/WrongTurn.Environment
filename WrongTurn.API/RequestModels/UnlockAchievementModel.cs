using System.ComponentModel.DataAnnotations;

namespace WrongTurn.API.RequestModels
{
    public class UnlockAchievementModel
    {
        [Required]
        public Guid PlayerId { get; set; }

        [Required]
        public string AchievementId { get; set; }
    }
}
