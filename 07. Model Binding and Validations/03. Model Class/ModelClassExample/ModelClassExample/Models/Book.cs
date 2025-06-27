using Microsoft.AspNetCore.Mvc;

namespace ModelClassExample.Models
{

    public class Book
    {
        [FromQuery]
        public int? bookid { get; set; } //bookid will take value from Quyerstring as
                                         //we have used [FromQuery]

        public string? author { get; set; } //author will take value from Routedata
                                            //but in url we mention value in QueryString


        //ToString method is used to print the properite values
        public override string ToString()
        {
            return $"book id: {bookid} and Author is: {author}";
        }
    }
}
