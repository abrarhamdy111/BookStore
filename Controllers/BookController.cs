using Abrar_Bookstore.Data.Services;
using Abrar_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace Abrar_Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _services;
        public BookController(IBookServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index(string searchTerm, string sortOrder)
        {
            var books = await _services.GetAllAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                books = books.Where(x => x.BookTitle.Contains(searchTerm) || x.BookGenre.Contains(searchTerm)).ToList();
            }

            switch (sortOrder)
            {
                case "price_asc":
                    books = books.OrderBy(x => x.BookPrice).ToList();
                    break;
                case "price_desc":
                    books = books.OrderByDescending(x => x.BookPrice).ToList();
                    break;
                case "date_asc":
                    books = books.OrderBy(x => x.PublicationDate).ToList();
                    break;
                case "date_desc":
                    books = books.OrderByDescending(x => x.PublicationDate).ToList();
                    break;
                case "title_asc":
                    books = books.OrderBy(x => x.BookTitle).ToList();
                    break;
                case "title_desc":
                    books = books.OrderByDescending(x => x.BookTitle).ToList();
                    break;
                default:
                    books = books.OrderBy(x => x.BookTitle).ToList(); 
                    break;
            }

            ViewData["SearchTerm"] = searchTerm;
            ViewData["SortOrder"] = sortOrder;

            return View(books);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _services.GetByIdAsync(id);
            if (book != null)
            {
                return View(book);
            }
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            var existinbook = await _services.GetByIdAsync(book.BookId);
            if (ModelState.IsValid && existinbook != null)
            {
                await _services.UpdateAsync(book);
                return RedirectToAction(nameof(Index));

            }
            return View(book);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _services.GetByIdAsync(id);
            if (book != null)
            {
                return View(book);
            }
            return View("NotFound");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
