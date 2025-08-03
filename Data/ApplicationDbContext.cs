using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Model;


namespace OnlineVotingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<VotingOccasion> VotingOccasions { get; set; }
    }
}
