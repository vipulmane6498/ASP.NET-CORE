using Microsoft.AspNetCore.Mvc;

namespace QueryStringVsRouteDataExample.Controllers
{
    public class HomeController : Controller
    {

        //http://localhost:5125/bookstore?bookid=20&isloggedin=true
        [Route("bookstore/{bookid?}/{isloggedin?}")]      
        public IActionResult Index(int? bookid, bool? isloggedin)
        {
            //BookId should be applied
            if (bookid.HasValue == false)
            {
                return BadRequest("Bookid is not supplied");//shorthand method -> return method with content.
            }

            //As you are recieving the value in method paramter you dont need to receive it using Request.Query like below
            //int bookid = Convert.ToInt32(HttpContext.Request.Query["bookid"]);

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
