using BudgetTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Areas.Identity.Data;

public class AppDbIdentityContext : IdentityDbContext<AppUser>
{
    public AppDbIdentityContext(DbContextOptions<AppDbIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        base.OnModelCreating(builder);

        var entities = builder.Model.GetEntityTypes();
        foreach (var entityType in entities)
        {
            var tableName = entityType.GetTableName();
            entityType.SetTableName(
                tableName?.Replace("AspNet", "") 
                ?? throw new ArgumentNullException("Table name cannot be null or empty")
            );
        }

        builder.Ignore<Budget>();
    }
}
