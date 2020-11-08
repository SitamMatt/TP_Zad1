using System;
using System.Collections.Generic;
using System.Text;
using Model.Data;
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
			ConstantDataFiller filler = new ConstantDataFiller();
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