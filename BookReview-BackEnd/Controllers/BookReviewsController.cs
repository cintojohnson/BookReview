#nullable disable
using Microsoft.AspNetCore.Mvc;
using BookReviewAPI.Models;
using BookReviewAPI.Interfaces;

namespace BookReviewAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookReviewsController : ControllerBase
    {
        private readonly IBookReviewService _service;

        public BookReviewsController(IBookReviewService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/BookReviews
        [HttpGet(Name = "GetBookReviews")]
        public ActionResult<IEnumerable<BookReview>> GetBookReviews()
        {
            return _service.GetBookReviews().ToList();
        }
    }
}
