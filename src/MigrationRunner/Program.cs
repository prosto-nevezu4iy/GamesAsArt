using GamesAsArt.MigrationRunner;
using Microsoft.Extensions.Configuration;

try
{
    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var builder = new ConfigurationBuilder();
    builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables();

    IConfiguration config = builder.Build();

    //Log.Logger = new LoggerConfiguration()
    //    .ReadFrom.Configuration(config)
    //    .CreateLogger();

    var connectionString =
            args.FirstOrDefault()
            ?? config.GetConnectionString("DefaultConnection");

    var migrationRunner = new DbUpMigrationRunner();
    migrationRunner.Migrate(connectionString);
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
    //Log.Error(ex, "Unhandled exception");
}
finally
{
    //await Log.CloseAndFlushAsync();
}

return 0;
