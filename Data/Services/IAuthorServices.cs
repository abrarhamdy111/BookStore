using Abrar_Bookstore.Models;

namespace Abrar_Bookstore.Data.Services
{
    public interface IAuthorServices
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task CreateAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
