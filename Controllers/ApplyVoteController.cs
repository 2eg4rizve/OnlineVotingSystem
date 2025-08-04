using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Managers.Interface;

namespace OnlineVotingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Required to extract VoterId from JWT
    public class ApplyVoteController : ControllerBase
    {
        private readonly IApplyVoteManager _manager;

        public ApplyVoteController(IApplyVoteManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyVote([FromBody] ApplyVoteRequest request)
        {
            var result = await _manager.ApplyVoteAsync(request);
            return Ok(new { message = result });
        }
    }
}
