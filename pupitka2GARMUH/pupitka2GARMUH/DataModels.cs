using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pupitka2GARMUH
{ 
        public class Book
        {
            public string Title { get; set; }   // Название
            public string Author { get; set; }  // Автор
            public string Year { get; set; }    // Год
            public string Status { get; set; }  // Статус (в фонде/на руках)
        }

        // Описание читателя
        public class Reader
        {
            public string FullName { get; set; } // ФИО
            public string Phone { get; set; }    // Телефон
            public string Ticket { get; set; }   // Номер билета
        }

        // Статическое хранилище (наши "массивы")
        public static class Storage
        {
            // Используем List (динамический массив), так как это стандарт C#
            public static List<Book> Books = new List<Book>();
            public static List<Reader> Readers = new List<Reader>();
        }
    
}
