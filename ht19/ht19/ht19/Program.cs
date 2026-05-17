using ht19;

var context = new BooksContext();

var books1 = context.Books
    .Where(b => b.Price > 300)
    .OrderByDescending(b => b.Price)
    .Select(b => new { b.Title, b.Price })
    .ToList();

var category2 = new Category("Programming");
var categories2 = context.Categories.Add(category2);
var book2 = new Book("Clean Code", 600, 1);
var books2 = context.Books.Add(book2);
context.SaveChanges();

var book3 = context.Books.Find(1);
book3.Price = 750;
context.SaveChanges();

var books4 = context.Books
    .Where(b => b.Category != null)
    .Select(b => new
    {
        b.Title,
        b.Category.CategoryName
    })
    .ToList();

var books5 = context.Books
    .GroupBy(b => b.CategoryId)
    .Select(c => new
    {
        CategoryId = c.Key,
        TotalBooks = c.Count()
    })
    .ToList();

var book6 = context.Books.Find(5);
book6.IsDeleted = true;
context.SaveChanges();