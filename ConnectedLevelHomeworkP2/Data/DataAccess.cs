using System.Data.SqlClient;
using System;

namespace ConnectedLevelHomeworkP2.Data
{
    public class DataAccess : IDisposable
    {
        private readonly SqlConnection connection;

        public DataAccess()
        {
            connection = new SqlConnection();
            connection.ConnectionString = "Server=WW\\MSSQLSERVER2017; Database=ConnectedLevelLesson; Trusted_Connection=True;";
            connection.Open();
        }

        public void CreateTable()
        {
            var createTableScript = "create table gruppa (Id int not null identity, [Name] nvarchar(max) not null);";

            using (var transaction = connection.BeginTransaction())
            using (var command = new SqlCommand(createTableScript, connection))
            {
                
                try
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
