namespace Form_urlencodedAndForm_data.Models
{
    public class Book
    {

        public int bookid { get; set; }

        public string author { get; set; }

        public override string ToString()
        {
            return $"Book id is: {bookid} and Auther is: {author}";
        }
    }
}
