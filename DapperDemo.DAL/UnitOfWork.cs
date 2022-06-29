using System.Data;
using System.Data.SqlClient;

namespace DapperDemo.DAL
{
    public class UnitOfWork : IDisposable
    {
        const string CONNECTION_STRING = @"Server=localhost\SQLEXPRESS;Database=BooksDbManyToMany;Trusted_Connection=True;";

        private IDbConnection _connection;
        private readonly BooksRepository _booksRepository;
        private readonly CategoriesRepository _categoriesRepository;

        public UnitOfWork()
        {
            _connection = new SqlConnection(CONNECTION_STRING);
            _connection.Open();

            _booksRepository = new BooksRepository(_connection);
            _categoriesRepository = new CategoriesRepository(_connection);
        }

        public BooksRepository Books
        {
            get
            {
                return _booksRepository ?? new BooksRepository(_connection);
            }
        }

        public CategoriesRepository Categories
        {
            get
            {
                return _categoriesRepository ?? new CategoriesRepository(_connection);
            }
        }

        #region Dispose methods
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
        #endregion

    }
}
