using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AuthorDataAccess : DbDataAccess<Author>
    {
        public override ICollection<Author> Select(string select)
        {
            var selectSqlScript = select;

            var command = factory.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var authors = new List<Author>();

            while (dataReader.Read())
            {
                authors.Add(new Author
                {
                    Id = int.Parse(dataReader["id"].ToString()),
                    FullName = dataReader["name"].ToString()
                });
            }

            dataReader.Close();
            command.Dispose();
            return authors;
        }
    }
}
