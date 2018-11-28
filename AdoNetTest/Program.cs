using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using Npgsql;


namespace AdoNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = "Server=127.0.0.1;Port=5432;Database=testDB;User Id=testuser;Password = 1234; ";
            NpgsqlConnection newConnection = new NpgsqlConnection(conString);
            newConnection.Open();

            Console.ReadKey();
            newConnection.Close();
           
        }
    }
}
