﻿
using System.Data;
using Dapper;
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

            var result = await _entity.AddAsync(entity);
            
            var resultCreated = await _app.SaveChangesAsync();
            return resultCreated > 0 ? "Created" : "Invalid";
        }

        public async ValueTask<string> Delete(int ?id)
        {
            if (id<=0)
                throw new ArgumentOutOfRangeException("Invalid Data");

            using (IDbConnection connection = new SqlConnection(_connection))
            {
                var Sql = $"SELECT * FROM {typeof(TEntity).Name} WHERE ID = @Id";
                TEntity entity = await connection.
                    QuerySingleOrDefaultAsync<TEntity>(Sql,new { Id = id});

                if (entity is null)
                    return "Not Found";

                _entity.Remove(entity);
                var resultDeleted = await _app.SaveChangesAsync();
                return resultDeleted > 0 ? "Deleted" : "Invalid";
            }
        }

        public async ValueTask<ICollection<TEntity>> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_connection))
            {
                string sql = $"SELECT * FROM {typeof(TEntity).Name}";
                var result = await connection.QueryAsync<TEntity>(sql);
                return result.ToList();
            }
        }

        public async ValueTask<TEntity> GetOne(int ?id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Invalid Data");

            TEntity entity ;
            using(IDbConnection connection = new SqlConnection(_connection))
            {
                var sql = $"SELECT * FROM {typeof(TEntity).Name} WHERE ID = @Id";
                entity = await connection.QuerySingleOrDefaultAsync<TEntity>(sql,new { Id = id});
                return entity;
            }
        }

        public async ValueTask<string> Update(TEntity entity, int ?id)
        {
            if (entity is null)
                throw new ArgumentNullException("Invalid Data");
            
            var found = await _entity.FindAsync(id);
            if (found is null)
                return "Not Found";

            _app.Entry(found).CurrentValues.SetValues(entity);
            var resultUpdate = await _app.SaveChangesAsync();
            return resultUpdate > 0 ? "Updated" : "Invalid";
        }
    }
}
