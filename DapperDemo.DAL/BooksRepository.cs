using DapperDemo.DAL.Models;
using System.Data;

namespace DapperDemo.DAL
{
    public class BooksRepository : GenericRepository<Book>
    {
        const string SELECT_ALL_BOOKS = "SELECT * FROM dbo.Books ";
        const string WHERE_BOOKS_BY_NAME = "WHERE Name LIKE @book_name ";

        public BooksRepository(IDbConnection dbConnection) : base(dbConnection) { }

        public List<Book> GetBooks(string bookNameSubstring)
        {
            return Get(
                $"{SELECT_ALL_BOOKS}{WHERE_BOOKS_BY_NAME}",
                new { book_name = $"%{bookNameSubstring}%" });
        }

        public List<Book> GetAllBooks()
        {
            return Get($"{SELECT_ALL_BOOKS}");
        }

    }
}
