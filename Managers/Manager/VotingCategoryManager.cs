using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;

namespace OnlineVotingSystem.Managers.Manager
{
    public class VotingCategoryManager : IVotingCategoryManager
    {
        private readonly IVotingCategoryRepository _repository;

        public VotingCategoryManager(IVotingCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommonResponse> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var response = data.Select(x => new VotingCategoryResponse
            {
                Id = x.Id,
                VotingOccasionName = x.VotingOccasion?.Name,
                UserEmail = x.User?.Email
            }).ToList();

            return new CommonResponse
            {
                status_code = 200,
                message = "Fetched all categories",
                status = "success",
                data = response
            };
        }

        public async Task<CommonResponse> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new CommonResponse
                {
                    status_code = 404,
                    message = "Not Found",
                    status = "error",
                    data = null
                };
            }

            var response = new VotingCategoryResponse
            {
                Id = entity.Id,
                VotingOccasionName = entity.VotingOccasion?.Name,
                UserEmail = entity.User?.Email
            };

            return new CommonResponse
            {
                status_code = 200,
                message = "Found",
                status = "success",
                data = response
            };
        }

        public async Task<CommonResponse> CreateAsync(VotingCategoryRequest request)
        {
            var entity = new VotingCategory
            {
                VotingOccasionId = request.VotingOccasionId,
                UserId = request.UserId
            };
            await _repository.AddAsync(entity);

            return new CommonResponse
            {
                status_code = 201,
                message = "Created",
                status = "success",
                data = entity
            };
        }

        public async Task<CommonResponse> UpdateAsync(int id, VotingCategoryRequest request)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return new CommonResponse
                {
                    status_code = 404,
                    message = "Not Found",
                    status = "error",
                    data = null
                };
            }

            existing.VotingOccasionId = request.VotingOccasionId;
            existing.UserId = request.UserId;

            await _repository.UpdateAsync(existing);

            return new CommonResponse
            {
                status_code = 200,
                message = "Updated",
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
                message = "Deleted",
                status = "success",
                data = null
            };
        }
    }
}
