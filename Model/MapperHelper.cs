using AutoMapper;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal static class MapperHelper
    {
        static MapperHelper()
        {
            config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Client, Client>();
                    cfg.CreateMap<Book, Book>();
                    cfg.CreateMap<BookCopy, BookCopy>();
                });
            Mapper = config.CreateMapper();
        }

        private static readonly MapperConfiguration config;

        public static IMapper Mapper { get; }
    }
}
