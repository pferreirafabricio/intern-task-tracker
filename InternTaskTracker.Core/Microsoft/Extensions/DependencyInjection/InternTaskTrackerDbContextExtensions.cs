using InternTaskTracker.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternTaskTracker.Core.Microsoft.Extensions.DependencyInjection;

public static class InternTaskTrackerDbContextExtensions
{
    public static IServiceCollection AddCoreDbContext(this IServiceCollection services, string connectionString)
        => services.AddSqlite<InternTaskTrackerDbContext>(connectionString);
}