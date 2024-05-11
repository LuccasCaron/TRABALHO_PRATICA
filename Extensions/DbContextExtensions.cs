using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;

namespace PROJETO_ADVOCACIA.Extensions;

public static class DbContextExtensions
{
    #region Properties

    private static string _connection = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    
    #endregion

    public static void AddCustomDbContext(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connection,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });
        });
    }

    //public static void MigrationInit(this IApplicationBuilder appBuilder)
    //{
    //    using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
    //    {
    //        var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    //        dbContext.Database.Migrate();
    //    }
    //}

}
