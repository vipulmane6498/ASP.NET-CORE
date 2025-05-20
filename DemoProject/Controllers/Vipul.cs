using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Vipul: ControllerBase
    {
        //private readonly IConfiguration _configuration; //

        //public Vipul(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        [HttpGet]
        public string GetName()
        {
            return "Vipul const";
        }

        [HttpPost]
        public string PostName([FromBody]string a, [FromQuery]string b)
        {
            return a+b;
        }


    }
}
