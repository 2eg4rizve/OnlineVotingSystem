namespace OnlineVotingSystem.Entities.RequestEntity
{
    public class UserSignupRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
