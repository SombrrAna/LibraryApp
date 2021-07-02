using System.Collections.Generic;

namespace Library
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BirthDate { get; set; }

        public List<Book> Books { get; set; }
    }
}
