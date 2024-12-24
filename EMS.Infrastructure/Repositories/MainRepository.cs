
using EMS.Infrastructure.Presistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Repositories
{
    public class MainRepository<TEntity> : IMainRepository<TEntity> where TEntity :class
    {
        private AppDbContext _app;
        private DbSet<TEntity> _entity;
        public MainRepository(AppDbContext app)
        {
            this._app = app;
            _entity = _app.Set<TEntity>();
        }
        public async ValueTask<string> Create(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");

            await _entity.AddAsync(entity);
            var resultCreated = await _app.SaveChangesAsync();
            return resultCreated > 0 ? "Created" : "Invalid";
        }

        public async ValueTask<string> Delete(int id)
        {
            if (id<=0)
                throw new ArgumentNullException("Invalid Data");

            var entity = await _entity.FindAsync(id); 
            if (entity is null)
                throw new Exception("Entity Not Found");

            _entity.Remove(entity);
            var resultDeleted = await _app.SaveChangesAsync();
            return resultDeleted > 0 ? "Deleted" : "Invalid";
        }

        public async ValueTask<ICollection<TEntity>> GetAll()
        {
            var entities = await  _entity.ToListAsync();
            if (entities is null)
                throw new Exception("Entity Not Found");

            return entities;
        }

        public async ValueTask<TEntity> GetOne(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            var entity = await _entity.FindAsync(id);
            if (entity is null)
                throw new Exception("Entity Not Found");

            return entity;
        }

        public async ValueTask<string> Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");

            _entity.Attach(entity);
            var resultUpdate = await _app.SaveChangesAsync();
            return resultUpdate > 0 ? "Update" : "Invalid";
        }
    }
}
