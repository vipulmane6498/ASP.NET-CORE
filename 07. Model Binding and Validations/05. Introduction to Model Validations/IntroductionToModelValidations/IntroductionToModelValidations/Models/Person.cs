using System.ComponentModel.DataAnnotations;

namespace IntroductionToModelValidations.Models
{
    public class Person
    {
        [Required] //this attribute -> property value should not be null/empty should should be some value
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }

    }
}
