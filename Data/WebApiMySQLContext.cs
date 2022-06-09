using Microsoft.EntityFrameworkCore;
using WebApiMySQL.Models;

namespace WebApiMySQL.Data
{
    public class WebApiMySQLContext : DbContext
    {
        public WebApiMySQLContext (DbContextOptions<WebApiMySQLContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Friend>().ToTable("friend");
            builder.Entity<VideoCollection>().ToTable("video_collection");

        }
        public DbSet<Friend>? Friends { get; set; }
        public DbSet<VideoCollection>? Videos { get; set; }


    }
}
