using DapperDemo.BLL;

using (var bll = new BookLibrary())
{
    var harryBooks = bll.GetBooks(nameSubstring: "Harry");

    var categories = bll.GetCategories(nameSubstring: "a");
}

Console.ReadLine();




































//using var connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=BooksDbManyToMany;Trusted_Connection=True;");
//connection.Open();
//var sql = $"SELECT * FROM dbo.Books WHERE Name = @book_name";
//var sqlParams = new { book_name = "Harry Potter" };
//var books = connection.Query<Book>(sql, sqlParams);
//Console.WriteLine();

//string jsonString = JsonSerializer.Serialize(books);
//sqlParams = new { book_name = jsonString };

//var resutl = connection.Query("dbo.getBooksWithPages",  commandType: System.Data.CommandType.StoredProcedure);
//Console.WriteLine();
