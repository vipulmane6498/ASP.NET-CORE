using Microsoft.AspNetCore.Mvc;
using Services;

namespace ServicesDIExample.Controllers
{
    public class HomeController : Controller
    {
        public readonly CitiesService _citiesService;

        public HomeController()
        {
            _citiesService = new CitiesService();
        }


        [Route("/")]
        public IActionResult Index()
        {
           List<string?> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
