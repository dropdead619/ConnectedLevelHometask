using Models;
using System;
using System.Collections.Generic;

namespace Data
{
    public class VisitorDataAccess : DbDataAccess<Visitor>
    {
        public void Delete(string delete)
        {
            var deleteSqlScript = delete;

            var command = factory.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = deleteSqlScript;
            command.ExecuteNonQuery();
        }
        public override ICollection<Visitor> Select(string select)
        {
            var selectSqlScript = select;

            var command = factory.CreateCommand();
            command.Connection = sqlConnection;
            command.CommandText = selectSqlScript;
            var dataReader = command.ExecuteReader();

            var debtors = new List<Visitor>();

            while (dataReader.Read())
            {
                debtors.Add(new Visitor
                {
                    Id = int.Parse(dataReader["id"].ToString()),
                    Name = dataReader["name"].ToString()
                });
            }

            dataReader.Close();
            command.Dispose();
            return debtors;
        }
    }
}
