using FromHeaderExample.Models;
using Microsoft.AspNetCore.Mvc;
using FromHeaderExample.CustomModelBinders;

namespace FromHeaderExample.Controllers
{
    public class HomeController : Controller
    {


        [Route("register")]
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Index( Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if (!ModelState.IsValid)
            {
              string error = string.Join("\n", ModelState.Values.SelectMany(
                  value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(error);   
            }
            return Content($"{person}, {UserAgent}");
        }
    }
}
