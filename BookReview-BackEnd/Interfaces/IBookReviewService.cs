using BookReviewAPI.Models;

namespace BookReviewAPI.Interfaces
{
    public interface IBookReviewService
    {
        IEnumerable<BookReview> GetBookReviews();
    }   
}
