using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Managers.Interface;

namespace OnlineVotingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class StartVotingController : ControllerBase
    {
        private readonly IStartVotingManager _manager;

        public StartVotingController(IStartVotingManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _manager.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _manager.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StartVotingRequest request) => Ok(await _manager.CreateAsync(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StartVotingRequest request) => Ok(await _manager.UpdateAsync(id, request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _manager.DeleteAsync(id));
    }
}
