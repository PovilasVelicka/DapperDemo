using Dapper;
using System.Data;

namespace DapperDemo.DAL.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _connection;
        public GenericRepository(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        protected List<TEntity> Get(string sql, object parametrs = null!, CommandType commandType = CommandType.Text)
        {
            return _connection.Query<TEntity>(sql, parametrs, commandType: commandType).ToList();
        }

        protected void Execute(string sql, object parametrs = null!, CommandType commandType = CommandType.StoredProcedure)
        {
            _connection.Query<TEntity>(sql, parametrs, commandType: commandType);
        }
    }
}
