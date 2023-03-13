using Microsoft.EntityFrameworkCore;
using BudgetTracker.Models;

namespace BudgetTracker.Data
{
    public class BudgetTrackerContext : DbContext
    {
        private EntityConfigFactory _entityConfigFactory;

        public BudgetTrackerContext(DbContextOptions<BudgetTrackerContext> options,
            EntityConfigFactory entityConfigFactory)
            : base(options)
        {
            _entityConfigFactory = entityConfigFactory;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var budgetConfig = _entityConfigFactory.Create<BudgetEntityConfig>(builder);
            var userAccountConfig = _entityConfigFactory.Create<UserAccountConfig>(builder);

            budgetConfig.Configure();
            userAccountConfig.Configure();
        }

        public DbSet<Budget> Budget { get; set; } = default!;
    }
}
