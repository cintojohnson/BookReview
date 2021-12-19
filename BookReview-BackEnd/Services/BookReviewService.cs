using BookReviewAPI.Interfaces;
using BookReviewAPI.Models;

namespace BookReviewAPI.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly BookReviewContext _context;
        public BookReviewService(BookReviewContext context)
        {
            _context = context ?? throw new ArgumentNullException("Argument context cannot be null");
        }

        public IEnumerable<BookReview> GetBookReviews()
        {
            return _context.BookReviews.OrderByDescending(x => x.AverageRating).ToList();
        }
    }
}
