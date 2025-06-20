using Microsoft.AspNetCore.Mvc;

namespace FileResultExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        public string Index()
        {
            return "You are on the Home Page!";
        }

        //1. VirtualFileResult -> When the file is in the wwwroot subfolder then use VirtualResult or
        //if the file is outside the wwwroot folder then use PhysicalFileResult
        [Route("file-download1")]
        public VirtualFileResult FileDownload1()
        {
            return new VirtualFileResult("/Hello.pdf", "application/pdf");
        }


        //2. PhysicalFileResult -> if the file is outside the wwwroot folder then use PhysicalFileResult.
        //you can use same PhysicalFileResult for files whicha are in wwwroot but its not a good practice
        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return new PhysicalFileResult("C:/Users/HP/Desktop/Hello.pdf", "application/pdf");
        }



        //3. FileContentResult -> when you want to return the byte array as the file then
        //you will use this file content result.
        //In case if you would like to give the byte array as low level data then file content result.
        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {

            // System.IO.File contains method ReadAllBytes which read the data and
            // convert into byte array further we are storing into byte array
            byte[] bytes= System.IO.File.ReadAllBytes(@"C:/Users/HP/Desktop/Hello.pdf");
            return new FileContentResult(bytes, "application/pdf");
        }
    }
}
