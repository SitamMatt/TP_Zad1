using System;

namespace Model.Data
{
    public class Book
    {
        public Book(string title, DateTime releaseDate, string author, string description, int pageCount)
        {
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Author = author;
            this.Description = description;
            this.PageCount = pageCount;

        }
        public string Title { get; }
        public DateTime ReleaseDate { get; }
        public string Author { get; }
        public string Description { get; }
        public int PageCount { get; }
    }
}
