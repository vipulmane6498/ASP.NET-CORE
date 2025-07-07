using System.ComponentModel.DataAnnotations;

namespace ModelBinderProviderExample.Models
{
    public class MinimumYearValidatorAttribute : ValidationAttribute  //ValidationAttribute -> this class
                                                                      //contains all inbuilt validations hence
                                                                      //inerite with this class
    {
        //Declare propery to store value
        public int MinimumYear { get; set; } = 2000; //if user dont provide any value in model property it will take this

        public string DefaultErrormessage { get; set; } = "Year should not be more than 2005 !";

        //parameterless Constructor
        public MinimumYearValidatorAttribute()
        {

        }
        //parameterized constuctor
        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }


        //This is inbuilt method in ValidationAttribute class we need to override it
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            //check if DateOfBirth is not null
            if (value != null)
            {
                DateTime date = (DateTime)value; //if not null then TypeCast into DateTime and store in variable

                if (date.Year >= MinimumYear) //date.Year -> user provided year  & Minimum year -> we set as a 2005 in model class
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrormessage, MinimumYear));
                    //this ErrorMessage property will pass the msge that we have provided above the property in CustomModel class DateOfBirth
                    //ErrorMessage=Date of birth should not be newer than jan 01, 2000
                }
                else
                {
                    return ValidationResult.Success; //given input is correct then return success
                }
            }

            return null; //return null when value is not provided
        }

    }
}
