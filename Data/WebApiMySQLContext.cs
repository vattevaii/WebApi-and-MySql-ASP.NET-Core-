using Microsoft.EntityFrameworkCore;
using WebApiMySQL.Models;

namespace WebApiMySQL.Data
{
    public class WebApiMySQLContext : DbContext
    {
        public WebApiMySQLContext(DbContextOptions<WebApiMySQLContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Friend>()
                .HasMany(f => f.videoCollections)
                .WithOne(v => v.Friend)
                .HasForeignKey(v => v.FriendId)
                .IsRequired();

            builder.Entity<Friend>().ToTable("friend");
            builder.Entity<VideoCollection>().ToTable("video_collection");

            builder.Entity<Friend>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).HasColumnName("friend_id").ValueGeneratedOnAdd();
                entity.Property(f => f.FirstName).IsRequired().HasMaxLength(45);
                entity.Property(f => f.LastName).HasMaxLength(45);
                // adress, city, state
                entity.Property(f => f.Address).HasMaxLength(45).IsRequired();
                entity.Property(f => f.City).HasMaxLength(45).IsRequired();
                entity.Property(f => f.State).HasMaxLength(45);

                entity.Property(f => f.PostCode).HasColumnName("post_code");
                entity.Property(f => f.HomePhone).HasColumnName("home_phone");
                entity.HasData(new Friend { Id = 1, FirstName = "sdfasw", LastName = "terei",
                    Address = "Thimi", City = "huusdfb", State = "3",
                    PostCode = "12345", HomePhone = "12345678" });
            });
            builder.Entity<VideoCollection>(entity =>
            {
                entity.Property(v => v.Id).HasColumnName("video_collection_id").ValueGeneratedOnAdd();
                entity.Property(v => v.Subject).IsRequired().HasMaxLength(45);
                entity.Property(v => v.Rating).IsRequired().HasPrecision(2,1);
                entity.Property(v => v.Length).IsRequired().HasPrecision(3,1);
                entity.Property(v => v.Note);
                entity.Property(v => v.YearReleased).HasColumnName("year_released").HasPrecision(4,0).IsRequired();
                entity.Property(v => v.MovieTitle).HasColumnName("movie_title").IsRequired().HasMaxLength(45);
                entity.Property(v => v.FriendId).HasColumnName("friend_id").IsRequired();
                entity.HasData(new VideoCollection { 
                    Id = 1, Length = 2.5,
                    MovieTitle = "This is bull",
                    Rating = 4.5,
                    Subject = "Bull Movie",
                    Note = "Best movie ever",
                    YearReleased = 2020, FriendId = 1 
                });

            });
            
        }

        
        
        public DbSet<Friend> Friends { get; set; } = null!;
        public DbSet<VideoCollection> Videos { get; set; } = null!;
    }
}
