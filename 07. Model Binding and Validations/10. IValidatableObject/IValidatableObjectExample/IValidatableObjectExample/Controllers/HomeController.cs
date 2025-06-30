using IValidatableObjectExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IValidatableObjectExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                   
                string error = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage)); 
                //if Format not worked use "Join"

                return BadRequest(error);
            }
            return Content($"{person}");
        }
    }
}
