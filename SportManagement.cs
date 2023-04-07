using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace week_3_assesment
{
    internal class SportManagement
    {
        SqlConnection connection;
        string connectionString = "Data Source = DESKTOP-50S2HSR;Initial Catalog=SportsManagementSystem;Integrated Security=True;Encrypt=False;";
        
        // initialize the sql connection
        public SportManagement() {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        // close the sql connection
        ~SportManagement()
        {
            connection.Close();
        }

        public void AddSport(string sportName)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO SPORTS VALUES('{sportName}')";
                command.ExecuteReader().Close();
                Console.WriteLine($"Sport {sportName} created successfully!!");
            }catch(SqlException exception)
            {
                Console.WriteLine($"Sport {sportName} not created successfully");
                Console.WriteLine("Error : " + exception.Message);
            }
        }

        public void AddTournament()
        {
          
            try
            {
                Console.WriteLine("Enter the name of the tournament");
                string tournamentName = Console.ReadLine();
                Console.WriteLine("Please Select The Sport ID Need to Be Added To This Tournament Below");
                SqlCommand command = connection.CreateCommand();
                // get all sports from the db
                command.CommandText = "SELECT * FROM SPORTS";
                SqlDataReader reader = command.ExecuteReader();

                // display the recieved database to the user via console
                while(reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        Console.Write(reader.GetValue(i));
                        Console.Write(" ");
                    }

                    Console.WriteLine("");
                }

                // close the command to use on further quries
                reader.Close();

                // get the id of the sport from the user
                int sportId = Convert.ToInt32(Console.ReadLine());

                command.CommandText = $"INSERT INTO TOURNAMENT VALUES('{tournamentName}', {sportId})";
                command.ExecuteReader().Close();
                Console.WriteLine($"Tournament {tournamentName} created successfully");
            }
            catch (SqlException exception)
            {
                Console.WriteLine($"Tournament not created successfully");
                Console.WriteLine("Error : " + exception.Message);
            }
        }

        private void _RemoveSport(int sportName)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM SPORTS WHERE NAME='{sportName}')";
                command.ExecuteReader().Close();
                Console.WriteLine($"Sport {sportName} deleted successfully!!");
            }
            catch (SqlException exception)
            {
                Console.WriteLine($"Sport {sportName} not deleted successfully");
                Console.WriteLine("Error : " + exception.Message);
            }
        }

        public void AddScoreBoard(int tournamentId)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO SCOREBOARD VALUES({tournamentId},0)";
                command.ExecuteReader().Close();
                Console.WriteLine("New Tournament Added To The Scoreboard");
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Scoreboard not Updated!!");
                Console.WriteLine("Error : " + exception.Message);
            }

        }

        public void EditScoreBoard(int scoreboardId, int score)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"UPDATE SCOREBOARD SET SCORE={score} WHERE ID={scoreboardId}";
                command.ExecuteReader().Close();
                Console.WriteLine("Score Updated To The Scoreboard");
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Score not updated To The Scoreboard");
                Console.WriteLine("Error : " + exception.Message);
            }

        }

        // remove the players based on their college and the tournament
        public void RemovePlayers(int tournamentId, string collegeName)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM PLAYERS WHERE COLLEGENAME='{collegeName}' AND TOURNAMENTID={tournamentId})";
                command.ExecuteReader().Close();
                Console.WriteLine("Players deleted successfully!!");
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Players not deleted successfully!!");
                Console.WriteLine("Error : " + exception.Message);
            }
        }

        public void RemoveTournament(int tournamentId)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM TOURNAMENT WHERE ID={tournamentId}";
                command.ExecuteReader().Close();
                Console.WriteLine("Tournament deleted successfully!!");
            }
            catch (SqlException exception)
            {
                Console.WriteLine("Tournament not deleted successfully!!");
                Console.WriteLine("Error : " + exception.Message);
            }

        }



    }
}
