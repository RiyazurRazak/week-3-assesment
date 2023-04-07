namespace week_3_assesment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SportManagement application = new SportManagement();
            application.AddSport("Football");
            application.AddSport("Chess");
            application.AddSport("Marathon");

            application.AddTournament();

            // add scoreboard for copa2023
            application.AddScoreBoard(3);

            application.EditScoreBoard(2, 50);

            application.RemoveTournament(2);


            // migration to initialize the database with the necessary tables with configuration

            //Migration migration = new Migration();
            //migration.Migrate();
        }
    }
}