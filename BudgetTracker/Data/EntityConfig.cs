using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetTracker.Data
{

    public class EntityConfigFactory
    {
        public EntityConfigFactory()
        {

        }
        public C Create<C>(ModelBuilder builder)
        {
            return (C)Activator.CreateInstance(typeof(C), new object[] { builder })!;
        }
    }

    public abstract class EntityConfig<E> where E : class
    {
        protected readonly EntityTypeBuilder<E> entityTypeBuilder;
        public EntityConfig(ModelBuilder modelBuilder)
        {
            entityTypeBuilder = modelBuilder.Entity<E>();
        }

        public void Configure()
        {
            ConfigureModel();
            ConfigureRelationships();
        }

        protected abstract void ConfigureModel();

        protected abstract void ConfigureRelationships();
    }
}
