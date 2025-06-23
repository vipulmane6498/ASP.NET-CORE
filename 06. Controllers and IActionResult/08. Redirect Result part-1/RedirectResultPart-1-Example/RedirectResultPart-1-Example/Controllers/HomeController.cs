using Microsoft.AspNetCore.Mvc;

namespace RedirectResultPart_1_Example.Controllers
{
    
    public class HomeController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index()
        {
            //BookId should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                return BadRequest("Bookid is not supplied");//shorthand method -> return method with content.
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

            //RedirectToActionResult for 302 Found -> required 3 values => (Actionmethod, ControllerName, RouteValue)
            //In below we dont want give any specific parameter value
            //hence we are adding dummy value as a anonymous value "new { }"
            // return new RedirectToActionResult("Books", "Store", new { }); //302 - Found

            //RedirectToActionResult for 301 Permanent -> required 4 values => (Actionmethod, ControllerName, RouteValue)
            return new RedirectToActionResult("Books", "Store", new { }, permanent: true); //301 -> permanent: true

        }
    }

    

}
