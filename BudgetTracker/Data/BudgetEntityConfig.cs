using BudgetTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BudgetTracker.Data
{
    internal class BudgetEntityConfig : EntityConfig<Budget>
    {
        public BudgetEntityConfig(ModelBuilder modelBuilder) : base(modelBuilder) { }

        protected override void ConfigureModel()
        {
            var entityBuilder = modelBuilder.Entity<Budget>();
            entityBuilder!.Property(m => m.UserAccountId)
                .IsRequired();
            entityBuilder!.Property(m => m.Name)
                .HasMaxLength(30)
                .IsRequired();
            entityBuilder!.Property(m => m.Description)
                .HasMaxLength(255);
            entityBuilder!.Property(m => m.Amount)
                .HasPrecision(11, 2)
                .IsRequired();
            entityBuilder!.Property(m => m.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("getdate()");
            entityBuilder!.Property(m => m.UpdatedDate)
                .HasDefaultValueSql("getdate()");
        }

        protected override void ConfigureRelationships()
        {
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.UserAccount)
                .WithMany(ua => ua.Budgets)
                .HasForeignKey(b => b.UserAccountId)
                .HasPrincipalKey(ua => ua.Id);

        }
    }
}
