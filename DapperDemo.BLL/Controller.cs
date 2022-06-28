using DapperDemo.DAL;
using System.Data;

namespace DapperDemo.BLL
{
    public class Controller: IDisposable
    {
        const string SELECT_ALL_BOOKS = "SELECT * FROM dbo.Books ";
        const string WHERE_BOOKS_BY_NAME = "WHERE Name = @book_name";
        const string BOOKS_PROCEDURE = "dbo.getBooksWithPages";

        const string SELECT_ALL_CATEGORIES = "SELECT * FROM dbo.Categories ";
        const string WHERE_CATEGORIES_BY_NAME = "WHERE Name = @category_name";

        private readonly DbRepository _repository;

        public Controller()
        {
            _repository = new DbRepository();
        }

        public List<Book> GetBooks(string bookName)
        {
            return _repository.Get<Book>(
                $"{SELECT_ALL_BOOKS}{WHERE_BOOKS_BY_NAME}",
                new { book_name = bookName });
        }

        public List<Book> GetBooks()
        {
            return _repository.Get<Book>($"{SELECT_ALL_BOOKS}");
        }

        public List<Book> GetBooksFromProc()
        {
            return _repository.Get<Book>(BOOKS_PROCEDURE, commandType: CommandType.StoredProcedure);
        }

        public List<Categories> GetCategories(string categoryName)
        {
            return _repository.Get<Categories>(
               $"{SELECT_ALL_CATEGORIES}{WHERE_CATEGORIES_BY_NAME}",
               new { category_name = categoryName });
        }

        public List<Categories> GetCategories()
        {
            return _repository.Get<Categories>($"{SELECT_ALL_CATEGORIES}");
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
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