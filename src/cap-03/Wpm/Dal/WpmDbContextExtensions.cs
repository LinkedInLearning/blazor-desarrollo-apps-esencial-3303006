using Microsoft.EntityFrameworkCore;

namespace Wpm.Dal;

public static class WpmDbContextExtensions
{
    public static void AddInMemoryWpmDb(this IServiceCollection services)
    {
        services.AddDbContext<WpmDbContext>(options =>
        {
            options.UseInMemoryDatabase("Wpm");
        });
    }

    public static void EnsureWpmDbIsCreated(this IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetService<WpmDbContext>()!;
        db.Database.EnsureCreated();
        db.Dispose();
    }
}
