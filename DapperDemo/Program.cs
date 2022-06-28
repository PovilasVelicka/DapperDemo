using DapperDemo.BLL;

using (var _controller = new Controller())
{
    var books = _controller.GetBooks("Harry Potter");

    var books2 = _controller.GetBooksFromProc();

    var categories = _controller.GetCategories("Fantasy");
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
