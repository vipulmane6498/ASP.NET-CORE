using Microsoft.AspNetCore.Mvc;
using ModelStateExample.Models;

namespace ModelStateExample.Controllers
{
    public class HomeController : Controller
    {

                [Route("register")]
            public IActionResult Index(Person person)
        {    
            if (!ModelState.IsValid) //in PostMan we mentioned "PersonName = empty" hence this will return false
            { 
                
                string error = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                //Above statement will read each value for each property and check if any validation error occur for any perticular property
                //and if found return error msg

                //ModelState.Values -> read each value from model class
                //SelectMany(value => value.Errors) -> return error object for each property can have 1 or more errors.
                //Select(err => err.ErrorMessage); -> for every validation error returns error message.
                 //string.Join("\n", -> join the error msg with new line character. Here we are separating error message with another line means 1st error msg will be on 1st line another will be on next line and so on

                //string error -> eventually store in error string

                return BadRequest(error); //return error with error msg
        }
            return Content($" {person}"); //return the output content which return ToString method values from Model class
        }
    }
}
