﻿using System;
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

        public Client fillClientData()
        {
            Client cl = new Client
            {
                Firstname = firstNames[rnd.Next(firstNames.Length)],
                Lastname = lastNames[rnd.Next(lastNames.Length)]
            };

            return cl;
        }

        public Book fillBookData()
        {
            Book book = new Book
            {
                Author = firstNames[rnd.Next(firstNames.Length)] + lastNames[rnd.Next(lastNames.Length)],
                Title = titles[rnd.Next(titles.Length)],
                PageCount = rnd.Next(100, 1000)
            };
            return book;
        }
    }
}