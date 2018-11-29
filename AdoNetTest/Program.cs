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
            /*
            string connectionString = "Server=127.0.0.1;Port=5432;Database=testDB;User Id=testuser;Password = 1234; ";
            NpgsqlConnection newConnection = new NpgsqlConnection(connectionString);
            newConnection.Open();
            NpgsqlCommand newQuery = new NpgsqlCommand();
            newQuery.Connection = newConnection;
            newQuery.CommandText = "INSERT INTO users (username, password) VALUES ('newuser1', '12345')";
            //newQuery.CommandText = "UPDATE users SET username = 'updatedusername' WHERE user_id = 2";
            int test = newQuery.ExecuteNonQuery();
            newQuery.CommandText = "SELECT @@IDENTITY";
            NpgsqlDataReader dataReader = newQuery.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine("PK: " + dataReader.GetInt32(0));
            }
            Console.ReadKey();
            Console.WriteLine(test);
            newQuery.CommandText = "SELECT * FROM users";
            dataReader = newQuery.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine("ID: " + dataReader.GetInt32(0) + " Username: " + dataReader.GetString(1) + " Password: " + dataReader.GetString(2));
            }
            Console.ReadKey();*/
            

            //Connection
            string connectionString = "Driver={Postgres ANSI};Server=localhost;Port=5432;Database=testDB;Uid = testuser; Pwd = 1234;";
            OdbcConnection newConnection = new OdbcConnection(connectionString);
            newConnection.Open();
            Console.WriteLine("Connected successfully.");
            newConnection.Close();

            //SELECT
            string command = "SELECT username FROM users WHERE username=user1";
            OdbcCommand cmd = new OdbcCommand(command, newConnection);
            OdbcDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine("ID: " + dataReader.GetInt32(0) + " Username: " + dataReader.GetString(1) + " Password: " + dataReader.GetString(2));
            }

            //INSERT
            command = "INSERT INTO users (username, password) VALUES ('newuser', '12345')";
            cmd = new OdbcCommand(command, newConnection);
            int affectedRows = cmd.ExecuteNonQuery();          
            Console.WriteLine(affectedRows);

            //UPDATE
            command = "UPDATE users SET username = 'updateduser' WHERE user_id = 2";
            cmd = new OdbcCommand(command, newConnection);
            affectedRows = cmd.ExecuteNonQuery();
            Console.WriteLine(affectedRows);

        }
    }
}
