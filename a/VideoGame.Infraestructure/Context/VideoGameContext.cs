using Microsoft.EntityFrameworkCore;
using VideoGame.Domain.Entities;

namespace VideoGame.Infrastructure.Context
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Genre).HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.HasMany(e => e.Games)
                      .WithOne()
                      .HasForeignKey(g => g.DeveloperId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Website).HasMaxLength(200);
                entity.HasMany(e => e.Games)
                      .WithOne()
                      .HasForeignKey(g => g.PublisherId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Manufacturer).HasMaxLength(100);
            });
        }
    }
}
