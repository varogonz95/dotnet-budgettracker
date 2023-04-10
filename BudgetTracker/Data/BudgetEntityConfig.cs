using BudgetTracker.Areas.Identity.Data;
using BudgetTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Data;

namespace BudgetTracker.Data
{
    internal class BudgetEntityConfig : EntityConfig<Budget>
    {
        public BudgetEntityConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void ConfigureModel()
        {
            entityTypeBuilder!
                .Property(m => m.Periodicity)
                .HasConversion<EnumToStringConverter<PeriodicityType>>()
                .HasMaxLength(
                    Enum.GetNames<PeriodicityType>()
                        .Select(p => p.Length).Max()
                    );
            entityTypeBuilder!
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();
            entityTypeBuilder!
                .Property(m => m.UpdatedDate)
                .HasDefaultValueSql("getdate()");
        }

        protected override void ConfigureRelationships()
        {
            entityTypeBuilder
                .HasMany<ExpenseDetail>()
                .WithOne(exp => exp.Budget)
                .HasForeignKey(exp => exp.BudgetId)
                .HasPrincipalKey(bud => bud.Id);

            entityTypeBuilder
                .HasOne(e => e.AppUser)
                .WithMany(e => e.Budgets);
        }
    }
}
