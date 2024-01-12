using FluentMigrator.Runner;
using Market.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal class Program
{
    private static IConfigurationRoot config;

    private static void Main(string[] args)
    {
        InitConfig();
        var dbContext = new DatabaseContext(config);
        var database = new DataBase(dbContext);
        //database.CreateDatabase("Products");

        var serviceProvider = CreateServices();

        //using (var scope = serviceProvider.CreateScope())
        //{
        //    RunMigration(scope.ServiceProvider);
        //}

        //new Helper().BulkInsertProducts();

       new ProductRepository(dbContext).CreateProduct(4, "Peach", 2000, 4);
    }

    private static void InitConfig()
    {
        var builder = new ConfigurationBuilder();

        builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        config = builder.Build();
    }

    public static IServiceProvider CreateServices()
    {
        return new ServiceCollection().AddLogging(c => c.AddFluentMigratorConsole())
                                      .AddFluentMigratorCore()
                                      .ConfigureRunner(c => c.AddSqlServer2012()
                                                             .WithGlobalConnectionString(config.GetConnectionString("Products"))
                                                             .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                                      .BuildServiceProvider(false);
    }

    private static void RunMigration(IServiceProvider serviceProvider)
    {
        var migrationService = serviceProvider.GetRequiredService<IMigrationRunner>();
        migrationService.ListMigrations();
        migrationService.MigrateUp();
    }
}