using Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repository;
        public int pageSize = 4;

        public BooksController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.Books
                .OrderBy(book => book.BookId)
                .Skip((page-1)*pageSize)
                .Take(pageSize));
        }
    }
}