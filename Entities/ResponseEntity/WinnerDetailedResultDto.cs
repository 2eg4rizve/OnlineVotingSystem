namespace OnlineVotingSystem.Entities.ResponseEntity
{
    public class WinnerDetailedResultDto
    {
        public int VotingOccasionId { get; set; }
        public string VotingOccasionName { get; set; }
        public int VotingOccasionsLevelId { get; set; }
        public string LevelName { get; set; }

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalVotes { get; set; }
    }
}
