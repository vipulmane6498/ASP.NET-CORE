    using Microsoft.AspNetCore.Mvc;
    using AllModelValidationsExample.Models;
    namespace AllModelValidationsExample.Controllers
    {
        public class HomeController : Controller
        {

            [Route("register")]
            public IActionResult Index(Person person)
            {
                if (!ModelState.IsValid)
                {

                string error=  string.Join("\n",  
                    ModelState.Values.SelectMany(value => 
                value.Errors).Select(err=>err.ErrorMessage));

                return Content(error);
                }

                return Content($"{person}");
            }
        }
    }
