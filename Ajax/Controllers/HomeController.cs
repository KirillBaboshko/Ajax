using Ajax.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace Ajax.Controllers
{
    public class HomeController : Controller
    {
        List<Book> books;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            books = new List<Book>();
            books.Add(new Book("Gogol", "Terminator", new DateOnly(1984, 1, 1)));
            books.Add(new Book("Gogol", "Terminator_2", new DateOnly(1991, 1, 1)));
            books.Add(new Book("Pushkin", "Titanik", new DateOnly(2001, 1, 1)));
            books.Add(new Book("Pushkin", "Titanik2", new DateOnly(2004, 1, 1)));
            books.Add(new Book("Pushkin", "Titanik Return", new DateOnly(2012, 1, 1)));
            books.Add(new Book("Steave Jobs", "Im a genius, you are idiots", new DateOnly(1984, 1, 1)));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult BookSearch(string name)
        {
            var allbooks = books.Where(item => item.Author == name).ToList();

            if (allbooks.Count<= 0)
            {
                return NotFound();
            }
            return PartialView(allbooks);
        }
    }
    public class Book
    {
        public Book(string author, string title, DateOnly publicationDay)
        {
            Author = author;
            Title = title;
            PublicationDay = publicationDay;
        }

        public string Author { get; set; }
        public string Title { get; set; }
        public DateOnly PublicationDay { get; set; }
    }
}