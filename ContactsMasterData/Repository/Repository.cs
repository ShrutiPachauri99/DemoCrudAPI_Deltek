using ContactsMasterData.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ContactsMasterData.Repository
{
    public abstract class Repository : IRepository.IRepository
    {
        protected Repository(ContactsMasterDbContext context)
        {
            Context = context;
        }

        public ContactsMasterDbContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task<TItem> Update<TItem>(TItem item) where TItem : class, new()
        {
            return await PerformAction(item, EntityState.Modified);
        }

        public async Task<TItem> Delete<TItem>(TItem item) where TItem : class, new()
        {
            return await PerformAction(item, EntityState.Deleted);
        }

        public async Task<TItem> Insert<TItem>(TItem item) where TItem : class, new()
        {
            return await PerformAction(item, EntityState.Added);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        protected virtual async Task<TItem> PerformAction<TItem>(TItem item, EntityState entityState)
            where TItem : class, new()
        {
            Context.Entry(item).State = entityState;
            await Context.SaveChangesAsync();
            return item;
        }
    }
}
