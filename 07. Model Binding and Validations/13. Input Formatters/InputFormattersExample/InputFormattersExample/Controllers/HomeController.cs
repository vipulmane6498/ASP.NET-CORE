using InputFormattersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace InputFormattersExample.Controllers
{
    public class HomeController : Controller
    {


        [Route("register")]
        //[Bind(nameof(person.PersonName), "Age", "DateOfBirth")]
        public IActionResult Index([FromBody]Person person)
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
