using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BookDataAccess : DbDataAccess<Book>
    {
        public override ICollection<Book> Select(string select)
        {
            var selectSqlScript = select;

            var command = factory.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var books = new List<Book>();

            while (dataReader.Read())
            {
                books.Add(new Book
                {
                    Id = int.Parse(dataReader["id"].ToString()),
                    Name = dataReader["name"].ToString()
                });
            }

            dataReader.Close();
            command.Dispose();
            return books;
        }
    }
}
