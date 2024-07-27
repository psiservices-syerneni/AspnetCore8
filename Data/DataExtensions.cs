using System.Net;
using Microsoft.EntityFrameworkCore;

namespace GameStore;

public static class DataExtensions
{
    public static void MigrateData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<GameDbContext>();
        dbcontext.Database.Migrate();
    }

}
