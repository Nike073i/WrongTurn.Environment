using Microsoft.AspNetCore.Mvc;
using WrongTurn.API.Services;
using WrongTurn.StateManagement;
using WrongTurn.StateManagement.Actions.Base;

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
        public async Task<IActionResult> SaveState(PlayerState playerState, IEnumerable<IPlayerAction> actions)
        {
            return Ok(await _playerStateService.ApplyChanges(playerState, actions));
        }

        [HttpPut("unlock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UnlockAchievement(Guid playerId, string achievementId)
        {
            await _playerStateService.MarkAchievementAsUnlocked(playerId, achievementId);
            return Ok();
        }
    }
}
