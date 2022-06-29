using DapperDemo.BLL;

using (var bll = new BookLibrary())
{
    var harryBooks = bll.GetBooks(nameSubstring: "Harry");

    var categories = bll.GetCategories(nameSubstring: "a");
}

Console.ReadLine();