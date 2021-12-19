using Microsoft.EntityFrameworkCore;

namespace BookReviewAPI.Models
{
    public class BookReviewContext : DbContext
    {
        public DbSet<BookReview>? BookReviews { get; set; }

        public BookReviewContext(DbContextOptions<BookReviewContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookReview>().ToTable("BookReview");
        }
    }
}
