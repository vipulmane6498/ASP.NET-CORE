using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CreatingControllersExample.Controllers
{
    public class HomeController 
    {
        [Route("sayhello")]
        public String Method1()
        {
            return "Hello from method1";
        }
    }
}
