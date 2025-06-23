using Microsoft.AspNetCore.Mvc;

namespace RedirectResultPart_1_Example.Controllers
{
    public class StoreController : Controller
    {

        [Route("store/books")]
        public IActionResult Books()
        {
            return Content("<h1>Book Store</h1>", "text/html");
        }
    }
}
