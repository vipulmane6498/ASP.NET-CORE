using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace CustomRouteConstraintClassExample.CustomConstraint
{
    public class MonthCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            //1. If the value is received for that key
            if (!values.ContainsKey(routeKey))
            {
                return false;
            }

            //2. Regex is a inbuilt class => If the incoming month values are matches with (jan|april|oct|sept) then return true 
            Regex regex = new Regex("^( jan|april|oct|sept)$");

            //3. value is already found hence it is in object type hence convert it in string
            string? monthValue = Convert.ToString(values[routeKey]); //routeKey => month. values[routeKey]=> incoming value for month.
                                                                     //further convert that value in string as it was in object type

            ////4. if the incoming month values are matches with (jan | april | oct | sept) then return true 
            if (regex.IsMatch(monthValue))
            {
                return true; //its match
            }
            return false;
        }
    }
}
