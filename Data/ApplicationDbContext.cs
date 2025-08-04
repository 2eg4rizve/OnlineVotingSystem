using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Model;


namespace OnlineVotingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<VotingOccasion> VotingOccasions { get; set; }

        public DbSet<VotingCategory> VotingCategories { get; set; }

        public DbSet<StartVoting> StartVotings { get; set; }

        public DbSet<ApplyVote> ApplyVotes { get; set; }


        public DbSet<VotingOccasionsLevel> VotingOccasionsLevels { get; set; }


        public DbSet<VotingOccasionsLevelMap> VotingOccasionsLevelMaps { get; set; }
    }
}
