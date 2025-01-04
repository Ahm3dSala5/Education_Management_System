
using System.Data;
using Dapper;
using System.Data.SqlClient;
using EMS.Infrastructure.Presistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EMS.Infrastructure.Repositories
{
    public class MainRepository<TEntity> : IMainRepository<TEntity> where TEntity :class
    {
        private AppDbContext _app;
        private DbSet<TEntity> _entity;
        private readonly string _connection;
        public MainRepository(AppDbContext app,IConfiguration config)
        {
            this._app = app;
            this._connection = config.GetConnectionString("ConStr")!;
            _entity = _app.Set<TEntity>();
        }
        public virtual async ValueTask<string> Create(TEntity entity)
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
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string sql = $"SELECT * FROM {typeof(TEntity).Name}";
                var result = await connection.QueryAsync<TEntity>(sql);

                if (result.Count() == 0)
                    throw new Exception($"{typeof(TEntity).Name} Not Have Any Item");
                return result.ToList();
            }
        }

        public async ValueTask<TEntity> GetOne(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            TEntity entity ;
            using(IDbConnection connection = new SqlConnection(_connection))
            {
                var sql = $"SELECT * FROM {typeof(TEntity).Name} WHERE ID = @Id";
                entity = await connection.QueryFirstAsync<TEntity>(sql,new { Id = id});
            }
            if (entity is null)
                throw new Exception($"{nameof(entity)} not found");

            return entity;
        }

        public async ValueTask<string> Update(TEntity entity, int id)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");
            
            var found = await _entity.FindAsync(id);
            if (found is null)
                throw new Exception($"{entity.GetType()} Not Found");

            _app.Entry(found).CurrentValues.SetValues(entity);
            var resultUpdate = await _app.SaveChangesAsync();
            return resultUpdate > 0 ? "Updated" : "Invalid";
        }
    }
}
