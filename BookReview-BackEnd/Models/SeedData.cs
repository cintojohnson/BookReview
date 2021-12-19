using Microsoft.EntityFrameworkCore;

namespace BookReviewAPI.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookReviewContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookReviewContext>>()))
            {
                if (context == null || context.BookReviews == null)
                {
                    throw new ArgumentNullException("Null BookReviewContext");
                }

                // Look for any movies.
                if (context.BookReviews.Any())
                {
                    return;   // DB has been seeded
                }

                context.BookReviews.AddRange(
                    new BookReview
                    {
                        Title = "Inner Circle",
                        Link = "https://www.goodreads.com//book/show/630104.Inner_Circle",
                        Series = "(Private #5)",
                        CoverLink = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1389046834l/630104.jpg",
                        Author = "Kate Brian",
                        AuthorLink = "https://www.goodreads.com/author/show/94091.Kate_Brian",
                        RatingCount = 7597,
                        ReviewCount = 196,
                        AverageRating = 4.03m
                    },
                    new BookReview
                    {
                        Title = "A Time to Embrace",
                        Link = "https://www.goodreads.com//book/show/9487.A_Time_to_Embrace",
                        Series = "(Timeless Love #2)",
                        CoverLink = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1433586236l/9487._SY475_.jpg",
                        Author = "Karen Kingsbury",
                        AuthorLink = "https://www.goodreads.com/author/show/3159984.Karen_Kingsbury",
                        RatingCount = 4179,
                        ReviewCount = 177,
                        AverageRating = 4.35m
                    },
                    new BookReview
                    {
                        Title = "Take Two",
                        Link = "https://www.goodreads.com//book/show/6050894-take-two",
                        Series = "(Above the Line #2)",
                        CoverLink = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1388271937l/6050894.jpg",
                        Author = "Karen Kingsbury",
                        AuthorLink = "https://www.goodreads.com/author/show/3159984.Karen_Kingsbury",
                        RatingCount = 6288,
                        ReviewCount = 218,
                        AverageRating = 4.23m
                    },
                    new BookReview
                    {
                        Title = "Reliquary",
                        Link = "https://www.goodreads.com//book/show/39030.Reliquary",
                        Series = "(Pendergast #2)",
                        CoverLink = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1386922100l/39030.jpg",
                        Author = "Douglas Preston",
                        AuthorLink = "https://www.goodreads.com/author/show/12577.Douglas_Preston",
                        RatingCount = 38382,
                        ReviewCount = 1424,
                        AverageRating = 4.01m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
