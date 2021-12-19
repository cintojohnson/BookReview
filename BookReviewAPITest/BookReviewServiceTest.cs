using Xunit;
using BookReviewAPI.Services;
using Microsoft.EntityFrameworkCore;
using BookReviewAPI.Models;
using System.Collections.Generic;

namespace BookReviewAPITest
{
    public class BookReviewServiceTest
    {

        [Fact]
        public void GetBookReviewsTest()
        {
            var options = new DbContextOptionsBuilder<BookReviewContext>()
            .UseInMemoryDatabase(databaseName: "BookReviewDatabase")
            .Options;

            //insert seed data
            using (var context = new BookReviewContext(options))
            {
                context.BookReviews.Add(new BookReview
                {
                    Id = 1,
                    Title = "Inner Circle",
                    Link = "https://www.goodreads.com//book/show/630104.Inner_Circle",
                    Series = "(Private #5)",
                    CoverLink = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1389046834l/630104.jpg",
                    Author = "Kate Brian",
                    AuthorLink = "https://www.goodreads.com/author/show/94091.Kate_Brian",
                    RatingCount = 7597,
                    ReviewCount = 196,
                    AverageRating = 4.03m
                });
                context.BookReviews.Add(new BookReview
                {
                    Id = 2,
                    Title = "A Time to Embrace",
                    Link = "https://www.goodreads.com//book/show/9487.A_Time_to_Embrace",
                    Series = "(Timeless Love #2)",
                    CoverLink = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1433586236l/9487._SY475_.jpg",
                    Author = "Karen Kingsbury",
                    AuthorLink = "https://www.goodreads.com/author/show/3159984.Karen_Kingsbury",
                    RatingCount = 4179,
                    ReviewCount = 177,
                    AverageRating = 4.35m
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BookReviewContext(options))
            {
                BookReviewService service = new BookReviewService(context);
                var reviews = (List<BookReview>)service.GetBookReviews();
                Assert.Equal(2, reviews.Count);
            }

        }
    }
}