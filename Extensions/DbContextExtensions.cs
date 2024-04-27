using Microsoft.EntityFrameworkCore;
using PROJETO_ADVOCACIA.Data;

namespace PROJETO_ADVOCACIA.Extensions;

public static class DbContextExtensions
{
    #region Properties

    private static string _connection = Environment.GetEnvironmentVariable("CONNECTION_STRING");

    #endregion

    public static void AddCustomDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(_connection,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });
        });
    }

}
