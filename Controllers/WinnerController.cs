using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Managers.Interface;

namespace OnlineVotingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] // Optional: Remove if public access is okay
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerManager _manager;

        public WinnerController(IWinnerManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> GetWinnerDetails([FromBody] WinnerRequest request)
        {
            var result = await _manager.GetWinnerDetailsAsync(request.VotingOccasionId, request.VotingOccasionsLevelId);
            return Ok(result);
        }
    }
}
