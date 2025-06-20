using Microsoft.AspNetCore.Mvc;
using JsonResultExample.Models;

namespace JsonResultExample.Controllers
{
    public class HomeController : Controller
    {



        [Route("home")]
        [Route("/")]
        public string Index()
        {
            return "HomePage !";
        }
        

        [Route("person")]
        public JsonResult Person()
        {

            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                firstName = "James",
                lastName = "Bond",
                age = 34

            };
            return new JsonResult(person);

        }
    }
}
