using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Services
{
    public class PizzaService
    {
        List<string> pizzas = new List<string> { "Margaritta", "garlickcheese" };

       
        public List<string> RetrievePizzas()
        {
            return pizzas;
        }



        public List<string> AddPizzas()
        {
            return pizzas;
        }



        public List<string> EditPizzas()
        {
            return pizzas;
        }


        public List<string> RemovePizzas()
        {
            return pizzas;
        }
    }
}
