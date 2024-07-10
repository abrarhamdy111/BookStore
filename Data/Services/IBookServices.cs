using Abrar_Bookstore.Models;

namespace Abrar_Bookstore.Data.Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
