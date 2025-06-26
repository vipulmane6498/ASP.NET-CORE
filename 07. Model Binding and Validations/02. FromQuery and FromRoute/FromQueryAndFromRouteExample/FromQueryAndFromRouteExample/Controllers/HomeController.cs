using Microsoft.AspNetCore.Mvc;

namespace FromQueryAndFromRouteExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        //http://localhost:5125/bookstore?bookid=20&isloggedin=true

        public IActionResult Index([FromQuery]int? bookid, [FromQuery]bool? isloggedin) //[FromQuery]
        //public IActionResult Index([FromRoute]int? bookid, [FromRoute]bool? isloggedin)  //[FromRoute]
        {
            //BookId should be applied
            if (bookid.HasValue == false)
            {
                return BadRequest("Bookid is not supplied");//shorthand method -> return method with content.
            }

            
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less than or equal to zero");
            }

            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            if (isloggedin == false)
            {
                return Unauthorized("User must be authorized");
            }

            //when above all condtion gets false true output
            return Content($"Book id: {bookid}", "text/plain");
        }
    }
}
