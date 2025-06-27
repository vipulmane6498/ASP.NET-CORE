using Microsoft.AspNetCore.Mvc;
using ModelClassExample.Models;

namespace ModelClassExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        //http://localhost:5080/bookstore/1/true?bookid=10&isloggedin=false&author=vipul
        public IActionResult Index([FromQuery] int? bookid, [FromRoute] bool? isloggedin, Book book) 
                                                                                //[FromQuery]Book book
        {
            
            if (bookid.HasValue == false)
            {
                return BadRequest("Bookid is not supplied");    
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
            return Content($"Book id: {bookid}, isloggedin: {isloggedin} and Author is: {book.author}", "text/plain");
        }
    }
}
