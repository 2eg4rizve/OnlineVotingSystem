using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;

namespace OnlineVotingSystem.Managers.Interface
{
    public interface IUserManager
    {
        Task<CommonResponse> Signup(UserSignupRequest request);
        Task<CommonResponse> Login(UserLoginRequest request);
    }
}
