using Data;
using Services;
using System;

namespace ConnectedLevelHometask
{
    class Program
    {
        static void Main(string[] args)
        {            
           ConfigurationService.Init();
           // 1) Выведите список должников.
           using(var visitorDataAccess = new VisitorDataAccess())
            {
                var debtors = visitorDataAccess.Select("select DISTINCT v.id, v.name from BooksVisitors bv join Books b on b.id = bv.bookId join Visitors v on v.id = bv.visitorId");
                foreach (var debtor in debtors)
                {
                    Console.WriteLine(debtor.Name);
                }
            }
            Console.WriteLine();
            // 2) Выведите список авторов книги №3(по порядку из таблицы ‘Book’).
            var authorDataAccess = new AuthorDataAccess();
            var bookThreeAuthors = authorDataAccess.Select("select a.id, a.name from BooksAuthors ba join Books b on b.id = ba.bookId join Authors a on a.id = ba.authorId where b.id = 3");
            foreach (var author in bookThreeAuthors)
            {
                Console.WriteLine(author.FullName);
            }
            authorDataAccess.Dispose();
            Console.WriteLine();
            //3) Выведите список книг, которые доступны в данный момент. 
            using (var bookDataAccess = new BookDataAccess())
            {
                var booksNotInUse = bookDataAccess.Select("Select b.id, b.name from Books b left join BooksVisitors bv on b.id = bv.bookId where ISNULL(visitorId, 0) = 0;");
                foreach (var book in booksNotInUse)
                {
                    Console.WriteLine(book.Name);
                }
                Console.WriteLine();
        
            //4) Вывести список книг, которые на руках у пользователя №2.
            var secondVisitorBooks = bookDataAccess.Select("Select b.id, b.name from Books b join BooksVisitors bv on b.id = bv.bookId where bv.visitorId = 2");
            foreach (var book in secondVisitorBooks)
            {
                Console.WriteLine(book.Name);
            }
            bookDataAccess.Dispose();
            Console.WriteLine();
            }
            //5) Обнулите задолженности всех должников. 
            using (var visitorDataAccess = new VisitorDataAccess())
            {
                visitorDataAccess.Delete("delete from BooksVisitors;");
                Console.WriteLine("All debts are forgiven!");
                Console.WriteLine();
            }
        }
    }
}
