using Dapper;
using System.Data;
using System.Data.SqlClient;
namespace DapperDemo.DAL
{
    public class DbRepository : IDisposable
    {
        const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;Database=BooksDbManyToMany;Trusted_Connection=True;";
        private readonly IDbConnection _connection;
        public DbRepository()
        {
            _connection = new SqlConnection(CONNECTION_STRING);
        }
        
        public List<T> Get<T>(string sql, object parametrs = null!, CommandType commandType = CommandType.Text)
        {
            var tempList = new List<T>();

            _connection.Open();
            tempList = _connection.Query<T>(sql, parametrs, commandType: commandType).ToList();
            _connection.Close();

            return tempList;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}
