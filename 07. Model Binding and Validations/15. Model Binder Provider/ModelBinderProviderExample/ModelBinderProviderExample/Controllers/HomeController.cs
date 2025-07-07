using ModelBinderProviderExample.Models;
using Microsoft.AspNetCore.Mvc;
using ModelBinderProviderExample.CustomModelBinders;

namespace ModelBinderProviderExample.Controllers
{
    public class HomeController : Controller
    {


        [Route("register")]
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Index( Person person)
        {
            if (!ModelState.IsValid)
            {
              string error = string.Join("\n", ModelState.Values.SelectMany(
                  value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(error);   
            }
            return Content($"{person}");
        }
    }
}
