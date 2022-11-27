using Microsoft.EntityFrameworkCore;
using WrongTurn.Data.Context;
using WrongTurn.Data.Entities;
using WrongTurn.Data.Exceptions;

namespace WrongTurn.Data.Repositories
{
    public abstract class DbRepository<TEntity> where TEntity : Entity
    {
        protected readonly WrongTurnDbContext DbContext;
        protected readonly DbSet<TEntity> Set;

        protected virtual IQueryable<TEntity> Items => Set;

        protected DbRepository(WrongTurnDbContext context)
        {
            DbContext = context;
            Set = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(int skip, int take)
        {
            return await Items.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Items.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Guid> RemoveByIdAsync(Guid id)
        {
            var entity = await Set.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) throw new EntityNotFoundException("Ошибка удаления записи по Id : Запись не найдена");
            DbContext.Entry(entity).State = EntityState.Deleted;
            await DbContext.SaveChangesAsync();
            return id;
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            var storedEntity = await Set.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (storedEntity == null)
                await Set.AddAsync(entity);
            else
                Set.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
    }
}
