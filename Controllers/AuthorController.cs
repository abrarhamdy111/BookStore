
 using Abrar_Bookstore.Data.Services;
using Abrar_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abrar_Bookstore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices _services;
        public AuthorController(IAuthorServices services)
        {
            _services = services;
        }
        public async Task <IActionResult> Index()
        {
            var author = await _services.GetAllAsync();
            return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _services.GetByIdAsync(id);
            if (author != null)
            {
                return View(author);
            }
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author author)
        {
            var existinAuthor = await _services.GetByIdAsync(author.AuthorId);
            if (ModelState.IsValid && existinAuthor != null)
            {
                await _services.UpdateAsync(author);
                return RedirectToAction(nameof(Index));

            }
            return View(author);
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await _services.GetByIdAsync(id);
            if (author != null)
            {
                return View(author);
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
