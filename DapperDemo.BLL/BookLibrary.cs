using DapperDemo.DAL;
using DapperDemo.DAL.Models;
namespace DapperDemo.BLL
{
    public class BookLibrary : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public BookLibrary()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Book> GetBooks(string nameSubstring)
        {
            return _unitOfWork.Books.GetBooks(nameSubstring);
        }

        public List<Category> GetCategories(string nameSubstring)
        {
            return _unitOfWork.Categories.GetCategories(nameSubstring);
        }

        #region Dispose methods
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
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
