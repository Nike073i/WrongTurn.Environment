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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByPlayerId(Guid playerId)
        {
            var player = await _playerStateService.GetPlayerState(playerId);
            return player != null ? Ok(player) : NotFound();
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveState([FromBody] SaveStateModel model)
        {
            try
            {
                return Ok(await _playerStateService.ApplyChanges(model.PlayerId, model.PlayerState, model.Actions));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Guid> CreatePlayer()
        {
            return await _playerStateService.CreatePlayer();
        }

        [HttpPut("unlock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UnlockAchievement([FromBody] UnlockAchievementModel model)
        {
            try
            {
                await _playerStateService.MarkAchievementAsUnlocked(model.PlayerId, model.AchievementId);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
