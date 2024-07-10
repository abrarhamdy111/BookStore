using Abrar_Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Abrar_Bookstore.Data.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly BookstoreDbContxt _contxt;
        public AuthorServices(BookstoreDbContxt contxt)
        {
            _contxt = contxt;
        }
        public async Task CreateAsync(Author author)
        {
            await _contxt.author.AddAsync(author);
            await _contxt.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existingAutor = await _contxt.author.FirstOrDefaultAsync(x => x.AuthorId == id);
             _contxt.author.Remove(existingAutor);
                await _contxt.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var result = await _contxt.author.ToListAsync();
            return result;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _contxt.author.FirstOrDefaultAsync(x=>x.AuthorId==id);
        }

        public async Task UpdateAsync(Author author)
        {
            var existingAuthor = await _contxt.author.FirstOrDefaultAsync(x => x.AuthorId == author.AuthorId);
            if (existingAuthor != null)
            {
                existingAuthor.AuthorName = author.AuthorName;
                existingAuthor.AuthorBio = author.AuthorBio;
                existingAuthor.DateOfBirth = author.DateOfBirth;
                await _contxt.SaveChangesAsync();
            }
        }

    }

}
