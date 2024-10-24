using DbUp;
using DbUp.Engine.Output;
using System.Reflection;

namespace GamesAsArt.MigrationRunner;
public class DbUpMigrationRunner
{
    public void Migrate(string connectionString)
    {
        EnsureDatabase.For.SqlDatabase(connectionString, new AutodetectUpgradeLog());

        var upgrader =
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToAutodetectedLog()
                .Build();

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            Console.Error.WriteLine(result.Error);
            //Log.Error(result.Error, "Migration failed!");
#if DEBUG
            Console.ReadLine();
#endif
        }

        Console.WriteLine("Success!");
        //Log.Information("Success!");
    }

}
