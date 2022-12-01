using Microsoft.AspNetCore.Mvc;
using WrongTurn.API.RequestModels;
using WrongTurn.API.Services;

namespace WrongTurn.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class PlayerStateController : ControllerBase
    {
        private readonly PlayerStateService _playerStateService;

        public PlayerStateController(PlayerStateService playerStateService)
        {
            _playerStateService = playerStateService;
        }

        [HttpGet("{playerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByPlayerId(Guid playerId)
        {
            return Ok(await _playerStateService.GetPlayerState(playerId));
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveState([FromBody] SaveStateModel model)
        {
            return Ok(await _playerStateService.ApplyChanges(model.PlayerId, model.PlayerState, model.Actions));
        }

        [HttpPut("unlock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UnlockAchievement([FromBody] UnlockAchievementModel model)
        {
            await _playerStateService.MarkAchievementAsUnlocked(model.PlayerId, model.AchievementId);
            return Ok();
        }
    }
}
