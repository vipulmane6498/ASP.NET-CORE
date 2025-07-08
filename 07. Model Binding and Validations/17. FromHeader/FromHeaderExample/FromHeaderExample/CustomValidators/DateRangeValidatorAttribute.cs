using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FromHeaderExample.Models
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }


        //need to store the comparison value hence creaate parameterized constructor and store in above property
        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                //get to_date
                DateTime to_date = Convert.ToDateTime(value);

                //get from_date using validationContext
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                //if otherProperty means FromDate is not null then 
                if (otherProperty != null)
                {
                    //Convert otherProperty means FromDate to DateTime format
                    DateTime? from_date = Convert.ToDateTime(otherProperty.GetValue(
                        validationContext.ObjectInstance)); //done Reflection

                    //if fromDate>Todate then return error msg
                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage); //this error msg define above property
                                                                   //ToDate
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }

                }
                return null;
            }

            return null;
        }

    }
}
