using Microsoft.EntityFrameworkCore;
using WebApiMySQL.Models;

namespace WebApiMySQL.Data
{
    public class WebApiMySQLContext : DbContext
    {
        public WebApiMySQLContext(DbContextOptions<WebApiMySQLContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VideoCollection>()
                .HasOne(v => v.Friend)
                .WithMany()
                .HasForeignKey(v => v.FriendId);

            builder.Entity<Friend>().ToTable("friend");
            builder.Entity<VideoCollection>().ToTable("video_collection");

            // Add items to Friends and VideoCollection

        }
        
        public DbSet<Friend> Friends { get; set; } = null!;
        public DbSet<VideoCollection> Videos { get; set; } = null!;
    }
}
