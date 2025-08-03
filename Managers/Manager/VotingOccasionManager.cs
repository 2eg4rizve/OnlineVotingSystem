using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class VotingOccasionManager : IVotingOccasionManager
    {
        private readonly IVotingOccasionRepository _repository;

        public VotingOccasionManager(IVotingOccasionRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommonResponse> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new CommonResponse
            {
                status_code = 200,
                message = "Data retrieved successfully",
                status = "success",
                data = data
            };
        }

        public async Task<CommonResponse> GetByIdAsync(int id)
        {
            var occasion = await _repository.GetByIdAsync(id);
            return new CommonResponse
            {
                status_code = occasion == null ? 404 : 200,
                message = occasion == null ? "Not Found" : "Data retrieved successfully",
                status = occasion == null ? "error" : "success",
                data = occasion
            };
        }

        public async Task<CommonResponse> CreateAsync(VotingOccasionRequest request)
        {
            var entity = new VotingOccasion { Name = request.Name };
            await _repository.AddAsync(entity);
            return new CommonResponse
            {
                status_code = 201,
                message = "Created successfully",
                status = "success",
                data = entity
            };
        }

        public async Task<CommonResponse> UpdateAsync(int id, VotingOccasionRequest request)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return new CommonResponse
                {
                    status_code = 404,
                    message = "Not found",
                    status = "error",
                    data = null
                };
            }

            existing.Name = request.Name;
            await _repository.UpdateAsync(existing);

            return new CommonResponse
            {
                status_code = 200,
                message = "Updated successfully",
                status = "success",
                data = existing
            };
        }

        public async Task<CommonResponse> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return new CommonResponse
            {
                status_code = 200,
                message = "Deleted successfully",
                status = "success",
                data = null
            };
        }
    }
}
