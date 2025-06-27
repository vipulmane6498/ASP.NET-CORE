using Microsoft.AspNetCore.Mvc;
using IntroductionToModelValidations.Models;
namespace IntroductionToModelValidations.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            return Content($"{person}");
        }
    }
}
