using BudgetTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Data
{
    internal class ExpenseDetailEntityConfig : EntityConfig<ExpenseDetail>
    {
        public ExpenseDetailEntityConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void ConfigureModel()
        {
        }

        protected override void ConfigureRelationships()
        {
            entityTypeBuilder
                .HasOne(e => e.Budget)
                .WithMany(e => e.ExpenseDetail)
                .HasForeignKey(e => e.BudgetId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}