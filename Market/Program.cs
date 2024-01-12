using Market;
using Market.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static IConfigurationRoot config;

    private static void Main(string[] args)
    {
        InitConfig();
        var dbContext = new DatabaseContext(config);
        var database = new DataBase(dbContext);
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IProductRepository, ProductRepository>();
        //serviceCollection.AddTransient<DatabaseContext, DatabaseContext>();
        //serviceCollection.AddTransient<IConfigurationRoot, ConfigurationRoot>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        //IProductRepository prRepo = serviceProvider.GetRequiredService<IProductRepository>();
        ProductService prServ = new ProductService(new ProductRepository(dbContext));
        var result = prServ.GetProductByName("Banana");
    }

    private static void InitConfig()
    {
        var builder = new ConfigurationBuilder();

        builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        config = builder.Build();
    }
}