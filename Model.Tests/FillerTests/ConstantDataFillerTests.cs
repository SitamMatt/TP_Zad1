using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Model.Data;
using Model.Data.Events;
using Model.Fillers;
using Model.Repository;
using NUnit.Framework;

namespace Model.Tests.FillerTests
{
	public class ConstantDataFillerTests
	{
        [Test]
		public void ConstantDataFiller_CorrectnesTest()
		{
            DataContext context = new DataContext();

            var clients = new List<Client>();
            var wykaz1 = new Client("Jan", "Kowalski");
            var wykaz2 = new Client("Jaros³aw", "Nowak");
            clients.Add(wykaz1);
            clients.Add(wykaz2);

            var katalogi = new Dictionary<string, Book>();
            var katalog1 = new Book("O dwóch takich co ukradli ksiê¿yc", DateTime.Parse("1999-02-01"), "Micha³ Milowicz", "Œwietna ksi¹¿ka", 50);
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

			ConstantDataFiller filler = new ConstantDataFiller(clients, katalogi, stany, zdarzenia);
			DataRepository repository = new DataRepository(filler);

            Assert.AreEqual(repository.GetClient(0).Firstname, "Jan");
			Assert.AreEqual(repository.GetClient(0).Lastname, "Kowalski");
			Assert.AreEqual(repository.GetClient(1).Firstname, "Jaros³aw");
			Assert.AreEqual(repository.GetClient(1).Lastname, "Nowak");

			Assert.AreEqual(repository.GetBook("fff-aahh").Author, "Micha³ Milowicz");
			Assert.AreEqual(repository.GetBook("hhshasdad").Author, "Jan Marczewski");

			Assert.AreEqual(repository.GetBookCopy(0).PurchaseDate, DateTime.Parse("2004-04-07"));
			Assert.AreEqual(repository.GetBookCopy(1).PurchaseDate, DateTime.Parse("2005-09-01"));
			Assert.AreEqual(repository.GetBookCopy(2).PurchaseDate, DateTime.Parse("2006-08-01"));

			Assert.AreEqual(repository.GetBookEvent(0).Client.Lastname, "Kowalski");
			Assert.AreEqual(repository.GetBookEvent(1).Date, DateTime.Parse("2018-06-01"));
			Assert.AreEqual(repository.GetBookEvent(2).BookCopy.PurchaseDate, DateTime.Parse("2006-08-01"));
		}
	}
}