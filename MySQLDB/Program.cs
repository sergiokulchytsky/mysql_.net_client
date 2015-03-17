using System;
using MySql.Data.MySqlClient;

namespace MySQLDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection myConnection = new MySqlConnection("Server=localhost; Database=database; Uid=Sergio; Pwd=123456");

            //OPEN CONNECTION
            myConnection.Open();

            //CREATE TABLE STATEMENT
            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = " CREATE TABLE Persons " +
                                    " ( " +
                                        " ID INT(5) NOT NULL AUTO_INCREMENT, " +
                                        " Name VARCHAR(255) NOT NULL, " +
                                        " City VARCHAR(255), " +
                                        " PRIMARY KEY (ID)" +
                                    " ) ";

            myCommand.ExecuteNonQuery();

            //-------------------------------------------------------
            //INSERT STATEMENT
            myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;
            myCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = "SERGIO";
            myCommand.Parameters.Add("@City", MySqlDbType.VarChar).Value = "Ternopil";

            myCommand.CommandText = "INSERT INTO Persons (Name, City) VALUES (@Name, @City);";
            myCommand.ExecuteNonQuery();

            //------------------------------------------------------
            //UPDATE STATEMENT
            myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;
            myCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = "SERGIO";
            myCommand.Parameters.Add("@NewName", MySqlDbType.VarChar).Value = "SEHIY";
            myCommand.CommandText = "UPDATE Persons SET Name = @NewName WHERE Name =  @Name;";
            myCommand.ExecuteNonQuery();

            //------------------------------------------------------
            //SELECT STATEMENT
            myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;
            myCommand.Parameters.Add("@City", MySqlDbType.VarChar).Value = "Ternopil";
            myCommand.CommandText = "SELECT Name FROM Persons WHERE City = @City;";
            MySqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"]);
            }
            reader.Close();

            //-----------------------------------------------------
            //DELETE STATEMENT
            myCommand = new MySqlCommand();
            myCommand.Connection = myConnection;
            myCommand.Parameters.Add("@City", MySqlDbType.VarChar).Value = "Ternopil";
            myCommand.CommandText = "DELETE FROM Persons WHERE City = @City;";
            myCommand.ExecuteNonQuery();

            myCommand.CommandText = "DROP TABLE Persons;";
            myCommand.ExecuteNonQuery();

            Console.ReadLine();

            //CLOSE CONNECTION
            myConnection.Close();
        }
    }
}