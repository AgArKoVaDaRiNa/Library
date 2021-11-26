using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library1 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ------------------------ 2 TASK --------------------------------------------

            //// Добавление
            //using (LibraryContext db = new LibraryContext())
            //{
            //    Author author1 = new Author { IdAuthor = 1, Surname = "Толстой", Name = "Лев", Patronymic = "" };
            //    Author author2 = new Author { IdAuthor = 2, Surname = "Франко", Name = "Иван", Patronymic = "" };

            //    // Добавление
            //    db.Authors.Add(author1);
            //    db.Authors.Add(author2);
            //    db.SaveChanges();
            //}

            //// получение
            //using (LibraryContext db = new LibraryContext())
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var authors = db.Authors.ToList();
            //    Console.WriteLine("Таблица после добавления:");
            //    foreach (Author a in authors)
            //    {
            //        Console.WriteLine($"{a.IdAuthor} - {a.Surname} {a.Name} {a.Patronymic}");
            //    }
            //}

            //// Редактирование
            //using (LibraryContext db = new LibraryContext())
            //{
            //    // получаем первый объект
            //    Author author = db.Authors.First();
            //    if (author != null)
            //    {
            //        author.Surname = "Котляревский";
            //        author.Name = "Иван";
            //        author.Patronymic = "";
            //        //обновляем объект
            //        db.Authors.Update(author);
            //        db.SaveChanges();
            //    }
            //    // выводим данные после обновления
            //    Console.WriteLine("\nТаблица после редактирования:");
            //    var users = db.Authors.ToList();
            //    foreach (Author a in users)
            //    {
            //        Console.WriteLine($"{a.IdAuthor} - {a.Surname} {a.Name} {a.Patronymic}");
            //    }
            //}

            //// Удаление
            //using (LibraryContext db = new LibraryContext())
            //{
            //    // получаем первый объект
            //    Author author = db.Authors.First();
            //    if (author != null)
            //    {
            //        //удаляем объект
            //        db.Authors.Remove(author);
            //        db.SaveChanges();
            //    }
            //    // выводим данные после обновления
            //    Console.WriteLine("\nТаблица после удаления:");
            //    var authors = db.Authors.ToList();
            //    foreach (Author a in authors)
            //    {
            //        Console.WriteLine($"{a.IdAuthor} - {a.Surname} {a.Name} {a.Patronymic}");
            //    }
            //}
            //Console.Read();

            // ------------------------ 3 TASK --------------------------------------------


            using (LibraryContext db = new LibraryContext())
            {
                //Виводимо перші десять книг
                var book = db.Books.Take(10);
                foreach (Book b in book)
                    Console.WriteLine("{0}\t {1}\t\t {2}", b.IdBook, b.BookSTitle, b.PublicationDate);
                Console.WriteLine("\n############################################################################################\n");

                //COUNT Виводимо кількість книг
                var book_count = db.Books.Count();
                Console.WriteLine($"Количество разных книг в библиотеке: {book_count}");
                Console.WriteLine("\n############################################################################################\n");

                //ORDERBY Виводимо книги по алфавіту
                var books = db.Books.OrderBy(x => x.BookSTitle).Take(10);
                foreach (Book b in books)
                    Console.WriteLine("{0}\t  {1}", b.IdBook, b.BookSTitle);
                Console.WriteLine("\n############################################################################################\n");

                //ORDERBYDESCENDING Виводимо книги з кінця алфавіту 
                var bookss = db.Books.OrderByDescending(x => x.BookSTitle).Take(10);
                foreach (Book b in bookss)
                    Console.WriteLine("{0}\t  {1}", b.IdBook, b.BookSTitle);
                Console.WriteLine("\n############################################################################################\n");

                //Виводимо видавництва, які знаходяться в городі КИЕВ
                var publ = db.Publishers.Where(x => x.PublishingCity.Contains("Киев"));
                foreach (Publisher p in publ)
                    Console.WriteLine("{0}\t {1}\t {2}", p.IdPublisher, p.PublisherName, p.PublishingCity);
                Console.WriteLine("\n############################################################################################\n");

                //UNION Об'єднуємо читачів та співробітників
                var un = db.LibraryCards.Select(x => new { Surname = x.Surname }).Union
                    (db.LibraryEmployees.Select(y => new { Surname = y.Surname }));
                foreach (var s in un)
                    Console.WriteLine(s.Surname);
                Console.WriteLine("\n############################################################################################\n");

                //EXCEPT Виводимо людей, які тільки працюють у бібліотеці, але не беруть там книги
                var ext = db.LibraryCards.Select(x => new { Surname = x.Surname }).Except
                    (db.LibraryEmployees.Select(y => new { Surname = y.Surname }));
                foreach (var s in ext)
                    Console.WriteLine(s.Surname);
                Console.WriteLine("\n############################################################################################\n");

                //INNER JOIN Виводимо фамілію, ID користувача та книгу, яку він забронював
                var bron = from card in db.LibraryCards join res in db.Reservations
                           on card.IdLibraryCard equals res.IdLibraryCard
                           select new { IdLibraryCard = card.IdLibraryCard, Surname = card.Surname, IdBook = res.IdBook };
                foreach (var x in bron)
                    Console.WriteLine("{0}   {1}     {2}", x.IdLibraryCard, x.Surname, x.IdBook);
                Console.WriteLine("\n############################################################################################\n");

                //GROUPBY Вирахували скільки видавництв в кожному місті
                var groups = db.Publishers.GroupBy(p => p.PublishingCity).Select(g => new { Name = g.Key, Count = g.Count() });
                foreach (var c in groups)
                    Console.WriteLine("{0}: {1} ", c.Name, c.Count);
                Console.WriteLine("\n############################################################################################\n");

                //SUM книг в наявності
                var sum = db.Books.Sum(x => x.BooksInStock);
                Console.WriteLine($"Сумарное количество книг: {sum}");

                //MAX
                var max = db.Books.Max(x => x.BooksInStock);
                Console.WriteLine($"Максимально книг: {max}");

                //MIN
                var min = db.Books.Min(x => x.BooksInStock);
                Console.WriteLine($"Минимально книг: {min}");

                //AVG
                var avg = db.Books.Average(x => x.BooksInStock);
                Console.WriteLine($"Среднее значение: {avg}");
                Console.WriteLine("\n############################################################################################\n");


                //Procedure Виводимо мінімальну та максимальну кількість книг в наявності
                var p1 = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@MinCount",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 50
                };
                var p2 = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@MaxCount",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 50
                };
                db.Database.ExecuteSqlRaw("GetBooksInStock @MINCount OUT, @MAXCount OUT", p1, p2);
                Console.WriteLine("Минимальное количество книг: {0},\n" +
                    "Максимальное количество книг: {1}", p1.Value, p2.Value);
                Console.WriteLine("\n############################################################################################\n");


                //Function Виводимо всі книги, які випущені до 2000 року
                var p3 = new Microsoft.Data.SqlClient.SqlParameter("@date", "2000-01-01");
                var booksss = db.Books.FromSqlRaw("SELECT * FROM GetBooksWithRightDate1 (@date)", p3).ToList();
                foreach (var b in booksss)
                    Console.WriteLine($"{b.IdBook} - {b.PublicationDate}, {b.IdPublisher}");
                Console.WriteLine("\n############################################################################################");


                //Захист : топ-10 книг, які найчастіше беруть
                var top = from bookk in db.Books join res in db.Reservations
                           on bookk.IdBook equals res.IdBook
                           select new { IdBook = bookk.IdBook, Title = bookk.BookSTitle};
                var nameTable = from x in top
                                group x by x.Title into g
                                select new { Name = g.Key, Count = g.Count() };
                var bookssss = nameTable.OrderByDescending(x => x.Count).Take(5);
                foreach (var x in bookssss)
                    Console.WriteLine("{0}   {1}    ", x.Name, x.Count );
                Console.WriteLine("\n############################################################################################\n");

            }
        }
    }
}

