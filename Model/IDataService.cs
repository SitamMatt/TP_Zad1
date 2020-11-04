﻿using System;

namespace Model
{
    public interface IDataService
    {
        void AddClient(string firstname, string lastname);

        void CheckoutBook(Client client, BookCopy bookCopy);

        void ReturnBook(BookCopy bookCopy);

        void ReturnBook(BookCheckout lending);

        void GetAllBookCopies(Book book);

        void GetAllBookCopies(string isbn);

        void GetRentalsBetween(DateTime from, DateTime to);

        void GetAllBooks();

        void GetAvailableBooks();

        void IsBookAvailable(Book book);

        void IsBookAvailable(string isbn);

        void GetNearestAvailabilityDate(Book book);

        void GetNearestAvailabilityDate(string isbn);

        void GetUsersHoldingCopyFor(TimeSpan duration);

        void GetAllRentalsForClient(Client client);
    }
}