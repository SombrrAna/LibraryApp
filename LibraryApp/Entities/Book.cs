using System.Collections.Generic;

namespace Library
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public int IssueYear { get; set; }
        public int PageNumber { get; set; }

        public List<Author> Authors { get; set; }

    }
}
