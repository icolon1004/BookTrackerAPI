using Microsoft.AspNetCore.Mvc;
using BookTrackerAPI.Services;

namespace BookTrackerAPI.Controllers
{
    [ApiController] //Tells ASP.Net "this is an API controller"
    [Route("api/[controller]")] //Routes token from each controller into api
    public class StatisticsControllers : ControllerBase
    {
        //reads from IBookService class
        private readonly IBookService _bookService;

        //constructor for referance of information for this file from IBookService
        public StatisticsControllers(IBookService bookService)
        {
            _bookService = bookService;
        }

        //retrieves information of statistics with summary parameter
        [HttpGet("summary")]
        public async Task<ActionResult<ReadingStatistics>> GetReadingStatistics()
        {
            var stats = await _bookService.GetReadingStatisticsAsync();
            return Ok(stats); //Ok() is used because HTTP needs to specify status code and formats as JSON which Ok() does automatically
        }

        //retrieves information of statistics with genre parameter
        [HttpGet("genres")]
        public async Task<ActionResult<Dictionary<string, int>>> GetGenreStatistics()
        {
            var stats = await _bookService.GetGenreStatisticsAsync();
            return Ok(stats); //Ok() is used because HTTP needs to specify status code and formats as JSON which Ok() does automatically
        }
    }
}
