using Microsoft.AspNetCore.Mvc;
namespace StatusCodeResultExample.Controllers
{     
    public class HomeController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            //BookId should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {

                //Instead of seperataly return status code and content
                //you can return the object of "new BadRequestResult()" or "BadRequest()" and
                //inside this object or method you can add content
                // Response.StatusCode = 400; //seperate status code
                // return Content("Bookid is not supplied"); //seperate content

                // return new BadRequestResult(); //return object
                //return new BadRequestObjectResult("Bookid is not supplied"); //return object with content
                return BadRequest("Bookid is not supplied");  //shorthand method -> return method with content.
            }

            //bookid cannot be null
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {         
                return BadRequest("Bookid cannot be empty !");
            }

            //1st Recieve bookid and store in variable
            //2nd  check Book id should be between 1 to 1000
            int bookid = Convert.ToInt32(HttpContext.Request.Query["bookid"]);
            if (bookid <= 0)
            {             
                return BadRequest("Book id can't be less than or equal to zero");
            }
            if (bookid > 1000)
            {               
                return NotFound("Book id can't be greater than 1000");
            }
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
             return Unauthorized("User must be authorized");
            }
            return File("/Hello.pdf", "application/pdf");
        }
    }

}
