namespace week_3_assesment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SportManagement application = new SportManagement();
            Console.WriteLine("Sports Management System");
            Console.WriteLine("Please Choose Any One Options");
            Console.WriteLine("1 Add Sport");
            Console.WriteLine("2 Add Tournament");
            Console.WriteLine("3 Add Scoreboard");
            Console.WriteLine("4 Edit ScoreBoard");
            Console.WriteLine("5 Remove Players");
            Console.WriteLine("6 Remove Tournament");

            Console.Write("Choose Any one option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    application.AddSport("");
                    break;
                case 2:
                    application.AddTournament();
                    break;
                case 3:
                    application.AddScoreBoard(3);
                    break;
                case 4:
                    application.EditScoreBoard(1, 50);
                    break;
                case 5:
                    application.RemovePlayers(1, "KONGU");
                    break;
                case 6:
                    application.RemoveTournament(2);
                    break;
                default:
                    Console.WriteLine("Invalid Option Selected");
                    break;
            }

            // migration to initialize the database with the necessary tables with configuration

            //Migration migration = new Migration();
            //migration.Migrate();
        }
    }
}