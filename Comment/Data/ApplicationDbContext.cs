using Comment.Data.Entities;
using Comment.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Comment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CommentEntity> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommentEntityTypeConfiguration());
        }
    }
}
