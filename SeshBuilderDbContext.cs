using dotnet_RPG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dotnet_RPG.Services
{
    public class SeshBuilderDbContext : DbContext
    {
        public DbSet<Pose> Poses {get; set;}
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SeshPose> SeshPoses { get; set; }

        public SeshBuilderDbContext(DbContextOptions<SeshBuilderDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeshPose>().HasKey(sp => new { sp.PoseId, sp.SessionId });
            // configures PoseId and SessionId as the composite key.

            modelBuilder.Entity<SeshPose>()
                .HasOne(x => x.Pose)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.PoseId);

            modelBuilder.Entity<SeshPose>()
                .HasOne(x => x.Session)
                .WithMany(x => x.PoseList)
                .HasForeignKey(x => x.SessionId);
        }
    }
}