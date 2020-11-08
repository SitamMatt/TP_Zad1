using Model.Data;
using Model.Data.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Repository
{
    public interface IDataRepository
    {
        void AddBook(string isbn, Book book);
        void AddBookCopy(BookCopy bookCopy);
        void AddBookEvent(BookEvent bookEvent);
        void AddClient(Client entity);
        void DeleteBook(string isbn);
        void DeleteBookCopy(BookCopy bookCopy);
        void DeleteCheckout(BookEvent bookEvent);
        void DeleteClient(Client client);
        IEnumerable<BookCopy> GetAllBookCopies();
        IEnumerable<BookEvent> GetAllBookEvents();
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Client> GetAllClient();
        Book GetBook(string isbn);
        BookCopy GetBookCopy(int index);
        BookEvent GetBookEvent(int index);
        Client GetClient(int key);
        void UpdateBook(string isbn, Book book);
        void UpdateBookCopy(int id, BookCopy bookCopy);
        void UpdateClient(int key, Client entity);
    }
}
