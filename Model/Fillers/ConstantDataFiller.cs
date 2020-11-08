﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Model.Data;
using Model.Data.Events;

namespace Model.Fillers
{
    public class ConstantDataFiller : IDataFiller
    {
        public void Fill(DataContext context)
        {
            var clients = new List<Client>();
            var wykaz1 = new Client("Jan", "Kowalski");
            clients.Add(wykaz1);
            var wykaz2 = new Client("Jarosław", "Nowak");
            clients.Add(wykaz2);
            var katalogi = new Dictionary<string, Book>();
            var katalog1 = new Book("O dwóch takich co ukradli księżyc", DateTime.Parse("1999-02-01"), "Michał Milowicz", "Świetna książka", 50);
            katalogi["fff-aahh"] = katalog1;
            var katalog2 = new Book("Bez nazwy", DateTime.Parse("2001-06-09"), "Jan Marczewski", "Ekstra", 255);
            katalogi["hhshasdad"] = katalog2;
            var stany = new ObservableCollection<BookCopy>();
            var opis1 = new BookCopy(katalog1, DateTime.Parse("2004-04-07"));
            stany.Add(opis1);
            var opis2 = new BookCopy(katalog2, DateTime.Parse("2005-09-01"));
            stany.Add(opis2);
            var opis3 = new BookCopy(katalog2, DateTime.Parse("2006-08-01"));
            stany.Add(opis3);
            var zdarzenia = new ObservableCollection<BookEvent>();
            var zdarz1 = new BookCheckoutEvent(wykaz1, opis1, DateTime.Parse("2018-04-01"));
            var zdarz3 = new BookReturnEvent(wykaz1, opis1, DateTime.Parse("2018-06-01"));
            zdarzenia.Add(zdarz1);
            zdarzenia.Add(zdarz3);
            var zdarz2 = new BookCheckoutEvent(wykaz2, opis3, DateTime.Parse("2020-08-01"));
            zdarzenia.Add(zdarz2);
            context.Clients = clients;
            context.Books = katalogi;
            context.BookCopies = stany;
            context.Events = zdarzenia;
        }
    }
}
