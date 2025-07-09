namespace Services
{
    public class CitiesService
    {
        //Create list of cities
        private readonly List<string?> _cities;

        //create paramterless constructor and add values in cities list
        public CitiesService() 
        {
            _cities = new List<string?>()
            {
                "Mumbai",
                "London",
                "Japan",
                "Hiroshima",
                "Nagasaki"
            };


        }

        //Retrieve city names
        public List<string?> GetCities()
        {
            return _cities;
        }
    }
}
