using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace week_3_assesment
{
    internal class Migration
    {
        SqlConnection connection;
        string connectionString = "Data Source = DESKTOP-50S2HSR;Initial Catalog=SportsManagementSystem;Integrated Security=True;Encrypt=False;";

        // initialize the sql connection
        public Migration()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        // close the sql connection
        ~Migration()
        {
            connection.Close();
        }


        // NOTE: this application references has enabled with cascade delete
        public void Migrate()
        {
            Console.WriteLine("Migration Begins.....");
            try
            {
                SqlCommand command = connection.CreateCommand();

                // crate table for sports
                command.CommandText = $"CREATE TABLE SPORTS (ID INT NOT NULL IDENTITY PRIMARY KEY, NAME VARCHAR(30) NOT NULL UNIQUE);";
                command.ExecuteReader().Close();

                // create table for tournaments ref with sports
                command.CommandText = $"CREATE TABLE TOURNAMENT (ID INT NOT NULL IDENTITY PRIMARY KEY,NAME VARCHAR(30) NOT NULL UNIQUE, TYPEOFSPORT INT NOT NULL FOREIGN KEY REFERENCES SPORTS (ID) ON DELETE CASCADE);";
                command.ExecuteReader().Close();

                // create table for scoreboard ref with tournament
                command.CommandText = $"CREATE TABLE SCOREBOARD(ID INT NOT NULL IDENTITY PRIMARY KEY, TOURNAMENTID INT NOT NULL FOREIGN KEY REFERENCES TOURNAMENT (ID) ON DELETE CASCADE,SCORE INT NOT NULL);";
                command.ExecuteReader().Close();

                // create table for players ref with tournament
                command.CommandText = $"CREATE TABLE PLAYERS(PLAYERID INT NOT NULL IDENTITY PRIMARY KEY, PLAYERNAME VARCHAR(30) NOT NULL, COLLEGENAME VARCHAR(30), TOURNAMENTID INT NOT NULL FOREIGN KEY REFERENCES TOURNAMENT (ID) ON DELETE CASCADE);";
                command.ExecuteReader().Close();
                Console.WriteLine($"Migrated Successfully!!!");
            }
            catch (SqlException exception)
            {
                Console.WriteLine($"Migration Not Done! Error !!");
                Console.WriteLine("Error : " + exception.Message);
            }
        }
    }
}
