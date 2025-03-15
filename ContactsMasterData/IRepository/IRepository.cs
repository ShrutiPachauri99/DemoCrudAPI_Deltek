namespace ContactsMasterData.IRepository
{
    public interface IRepository : IDisposable
    {
        Task<TItem> Update<TItem>(TItem item) where TItem : class, new();

        Task<TItem> Delete<TItem>(TItem item) where TItem : class, new();

        Task<TItem> Insert<TItem>(TItem item) where TItem : class, new();
        void Save();
    }
}
