namespace BookReviewAPI.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Series { get; set; } = string.Empty;
        public string CoverLink { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string AuthorLink { get; set; } = string.Empty;
        public int RatingCount { get; set; }
        public int ReviewCount { get; set; }
        public decimal AverageRating { get; set; }
    }
}
