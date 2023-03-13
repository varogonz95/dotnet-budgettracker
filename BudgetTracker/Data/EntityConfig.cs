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
        protected readonly ModelBuilder modelBuilder;
        public EntityConfig(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public virtual void Configure()
        {
            ConfigureModel();
            ConfigureRelationships();
        }

        protected abstract void ConfigureModel();

        protected abstract void ConfigureRelationships();
    }
}
