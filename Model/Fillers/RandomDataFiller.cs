using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Model.Data;

namespace Model.Fillers
{
    class RandomDataFiller
    {
        private string[] firstNames = { "Adam", "Albert", "Aleksander", "Andrzej", "Antoni", "Bartłomiej", "Bronisław", "Dariusz",
        "Dawid", "Dominik", "Filip"};
        private string[] lastNames = { "Adamiak", "Boryszewski", "Dąbrowski", "Frączczak", "Gołąb" };
        private string[] titles = { "Duma i uprzedzenie", "Ania z Zielonego Wzgórza", "Władca Pierścieni", "Lśnienie", "Zielona Mila", "Don Kichot",
        "Przygody Tomka Sawyera", "Podróże Guliwera", "Podróż do wnętrza Ziemi", "Wichrowe Wzgórza"};

        private Random rnd = new Random();

        public DateTime randomDay(DateTime startDay)
        {
            int range = (DateTime.Today - startDay).Days;
            return startDay.AddDays(rnd.Next(range));
        }

        public Client fillClientData()
        {
            Client cl = new Client(firstNames[rnd.Next(firstNames.Length)], lastNames[rnd.Next(lastNames.Length)]);
            return cl;
        }

        public Book fillBookData()
        {
            Book book = new Book(titles[rnd.Next(titles.Length)], randomDay(new DateTime(1997, 1, 1)),
                (firstNames[rnd.Next(firstNames.Length)] + " " + lastNames[rnd.Next(lastNames.Length)]), "brak opisu", rnd.Next(30, 1000));
            return book;
        }
    }
}
