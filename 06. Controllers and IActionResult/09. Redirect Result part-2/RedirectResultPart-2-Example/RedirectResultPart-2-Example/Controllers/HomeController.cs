using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace RedirectResultPart_2_Example.Controllers
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

            //302 - Found - RedirectToActionResult
            //RedirectToActionResult -> RedirectToActionResult is better because easily you can change the action method
            //name, controller name,
            //and you can also make it dynamic by storing them into some variables and you can check some conditions
            //based on it. 
            //return new RedirectToActionResult("Books", "Store", new { id = bookid }); //302 - Found
            //return RedirectToAction("Books", "Store", new { id = bookid });

            //301 - Moved Permanently - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new { }, permanent: true); //301 - Moved Permanently
            //return RedirectToActionPermanent("Books", "Store", new { id = bookid });



            //302 - Found - LocalRedirectResult
            //LocalRedirectResult -> if your url is a bit complex one is different than the simple action name and c
            //Controller name let's say it is the url for a log file in that case local redirect result is better. 
            //return new LocalRedirectResult($"store/books/{bookid}"); //302 - Found
            //return LocalRedirect($"store/books/{bookid}"); //302 - Found

            //301 - Moved Permanently - LocalRedirectResult
            //return new LocalRedirectResult($"store/books/{bookid}", true); //301 - Moved Permanently
            //return LocalRedirectPermanent($"store/books/{bookid}"); //301 - Moved Permanently


            //302 - Found - Redirect
            //return Redirect($"store/books/{bookid}"); //302 - Found

            //301 - Moved Permanently - Redirect
            return RedirectPermanent($"store/books/{bookid}"); //301 - Moved Permanently

        }
    }

}
