namespace EMS.Infrastructure.Repositories
{
    public interface IMainRepository<TEntity> where TEntity : class
    {
        ValueTask<string> Create(TEntity entity);
        ValueTask<TEntity> GetOne(int id);
        ValueTask<ICollection<TEntity>> GetAll();
        ValueTask<string> Update(TEntity entity);
        ValueTask<string> Delete(int id);
    }
}
