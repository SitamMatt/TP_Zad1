using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Book
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
    }
}
