using Microsoft.EntityFrameworkCore;
using BudgetTracker.Models;
using BudgetTracker.Areas.Identity.Data;

namespace BudgetTracker.Data
{
    public class AppDbContext : DbContext
    {
        private readonly EntityConfigFactory _entityConfigFactory;

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            EntityConfigFactory entityConfigFactory
        ) : base(options)
        {
            _entityConfigFactory = entityConfigFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var budgetConfig = _entityConfigFactory.Create<BudgetEntityConfig>(builder);
            var expenseDetailConfig = _entityConfigFactory.Create<ExpenseDetailEntityConfig>(builder);

            budgetConfig.Configure();
            expenseDetailConfig.Configure();

            builder.Ignore<AppUser>();
        }

        public DbSet<Budget> Budget { get; set; } = default!;
        public DbSet<ExpenseDetail> ExpenseDetail { get; set; } = default!;
    }
}
