namespace OnlineVotingSystem.Entities.RequestEntity
{
    public class VotingOccasionsLevelMapRequest
    {
        public int VotingOccasionId { get; set; }
        public string LevelName { get; set; }
        public int VotingOccasionsLevelId { get; set; }
        public int PersonId { get; set; }
    }
}
