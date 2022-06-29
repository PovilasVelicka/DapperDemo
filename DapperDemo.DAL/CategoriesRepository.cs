using DapperDemo.DAL.Models;
using System.Data;

namespace DapperDemo.DAL
{
    public class CategoriesRepository : GenericRepository<Category>
    {
        const string SELECT_ALL_CATEGORIES = "SELECT * FROM dbo.Categories ";
        const string WHERE_CATEGORIES_BY_NAME = "WHERE Name LIKE @category_name ";

        public CategoriesRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public List<Category> GetCategories(string categoryNameSubstring)
        {
            return Get(
               $"{SELECT_ALL_CATEGORIES}{WHERE_CATEGORIES_BY_NAME}",
               new { category_name = $"%{categoryNameSubstring}%" });
        }

        public List<Category> GetAllCategories()
        {
            return Get($"{SELECT_ALL_CATEGORIES}");
        }
    }
}
