using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineVotingSystem.Model
{
    public class VotingCategory
    {
        public int Id { get; set; }

        [ForeignKey("VotingOccasion")]
        public int VotingOccasionId { get; set; }
        public VotingOccasion VotingOccasion { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
