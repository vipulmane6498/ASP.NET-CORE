
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MultipleActionMethodsExample.Controllers
{

    [Controller]
    public class Home
    {
        //1.Action Method
        //You can use multiple route templates for single method
        [Route("home")]
        [Route("/")]
        public string Index() //serves as the default action when no specific method is mentioned in the URL
        {
            return "You are in Home Page !";
        }


        //2.Action Method -> About
        [Route("/about")]
        public string About()
        {
            return "You are in About Page !";
        }

        //3.Action Method -> Contact
        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "You are in Contact Page !";
        }

    }
}
