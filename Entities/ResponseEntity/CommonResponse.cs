namespace OnlineVotingSystem.Entities.ResponseEntity
{
    public class CommonResponse
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public object data { get; set; }
    }
}
