using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using ModelValidatorMultiplePropEg.Models;

namespace ModelValidatorMultiplePropEg.Controllers
{
    public class HomeController : Controller
    {


        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => 
                value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }

            return Content($"{person}");
        }
    }
}
