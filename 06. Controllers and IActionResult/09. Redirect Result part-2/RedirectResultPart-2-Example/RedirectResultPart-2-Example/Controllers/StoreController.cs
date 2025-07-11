﻿using Microsoft.AspNetCore.Mvc;

namespace RedirectResultPart_2_Example.Controllers
{
    public class StoreController : Controller
    {

        [Route("store/books/{id}")]
        public IActionResult Books()
        {
         int id= Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>Book Store: {id} </h1>", "text/html");
        }
    }
}
