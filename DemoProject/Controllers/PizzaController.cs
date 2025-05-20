using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return  qnew string[] { "value1", "value2" };
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PizzaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
