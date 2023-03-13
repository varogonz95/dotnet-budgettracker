using BudgetTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Data
{
    internal class UserAccountConfig : EntityConfig<UserAccount>
    {
        public UserAccountConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void ConfigureModel()
        {
            return;
        }

        protected override void ConfigureRelationships()
        {
            return;
        }
    }
}