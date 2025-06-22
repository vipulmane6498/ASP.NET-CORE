using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("book")]
        public IActionResult Index()
        {
            //BookId should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Bookid is not supplied");
            }

            //bookid cannot be null
            if ( string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Bookid cannot be empty !");
            }

            //1st Recieve bookid and store in variable
            //2nd  check Book id should be between 1 to 1000
            int bookid = Convert.ToInt32(HttpContext.Request.Query["bookid"]);
            if(bookid <= 0)
            {
                Response.StatusCode = 400;
                return Content("Book id can't be less than or equal to zero");
            }
            if (bookid > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id can't be greater than 1000");
            }

            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false){

                Response.StatusCode = 401;
                return Content("User must be authenticated");
            }

            return File("/Hello.pdf", "application/pdf");
        }
    }
}
