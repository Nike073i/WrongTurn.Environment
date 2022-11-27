using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrongTurn.Data.Entities;

namespace WrongTurn.Data.Context.Configurations
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
