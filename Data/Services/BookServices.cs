using Abrar_Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Abrar_Bookstore.Data.Services
{
    public class BookServices : IBookServices
    {
        private readonly BookstoreDbContxt _contxt;
        public BookServices(BookstoreDbContxt contxt)
        {
            _contxt = contxt;
        }
        public async Task CreateAsync(Book book)
        {
            await _contxt.book.AddAsync(book);
            await _contxt.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existingAuthor = await _contxt.book.FirstOrDefaultAsync(x => x.BookId == id);
            if (existingAuthor != null)
            {
                _contxt.book.Remove(existingAuthor);
                await _contxt.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var result = await _contxt.book.ToListAsync();
            return result;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _contxt.book.FirstOrDefaultAsync(x => x.BookId == id);
        }

        public async Task UpdateAsync(Book book)
        {
            var existingbook = await _contxt.book.FirstOrDefaultAsync(x => x.BookId == book.BookId);
            if (existingbook != null)
            {
                existingbook.BookTitle = book.BookTitle;
                existingbook.BookGenre = book.BookGenre;
                existingbook.BookPrice = book.BookPrice;
                existingbook.ImgeURL = book.ImgeURL;
                existingbook.PublicationDate = book.PublicationDate;
                await _contxt.SaveChangesAsync();
            }
        }
    }
}
