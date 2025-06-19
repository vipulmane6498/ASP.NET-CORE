using Microsoft.AspNetCore.Mvc;

namespace ContentResultExample.Controllers
{

    
    public class HomeController : Controller //To use inbuilt methods of controller class then inherit with the same
    {


        [Route("/home")]
        public ContentResult Index()
        {

            //ContentResult() -> to return altered response 
            //return new ContentResult()
            //{
            //    Content = "hello there !",
            //    ContentType = "text/plain"
            //};

            //Content() method -> it is predefined method in Controller class which we have used for inheritance here
            return Content("<h1>Hello There !</h1>  <h4>Hello from Index</h4>", "text/html");
                
        }
    }
}
