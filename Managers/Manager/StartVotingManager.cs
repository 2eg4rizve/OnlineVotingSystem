using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class StartVotingManager : IStartVotingManager
    {
        private readonly IStartVotingRepository _repository;

        public StartVotingManager(IStartVotingRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommonResponse> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return new CommonResponse { status_code = 200, message = "Success", status = "Success", data = list };
        }

        public async Task<CommonResponse> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
                return new CommonResponse { status_code = 404, message = "Not found", status = "Error" };

            return new CommonResponse { status_code = 200, message = "Success", status = "Success", data = item };
        }

        public async Task<CommonResponse> CreateAsync(StartVotingRequest request)
        {
            var newItem = new StartVoting
            {
                VotingOccasionId = request.VotingOccasionId,
                StartTime = request.StartTime,
                EndTime = request.EndTime
            };

            await _repository.AddAsync(newItem);

            return new CommonResponse { status_code = 200, message = "Created", status = "Success", data = newItem };
        }

        public async Task<CommonResponse> UpdateAsync(int id, StartVotingRequest request)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return new CommonResponse { status_code = 404, message = "Not found", status = "Error" };

            existing.VotingOccasionId = request.VotingOccasionId;
            existing.StartTime = request.StartTime;
            existing.EndTime = request.EndTime;

            await _repository.UpdateAsync(existing);

            return new CommonResponse { status_code = 200, message = "Updated", status = "Success", data = existing };
        }

        public async Task<CommonResponse> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return new CommonResponse { status_code = 200, message = "Deleted", status = "Success" };
        }
    }
}
