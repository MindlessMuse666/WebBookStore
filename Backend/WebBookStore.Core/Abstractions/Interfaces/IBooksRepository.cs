using WebBookStore.Core.Models;

namespace WebBookStore.Core.Abstractions.Interfaces;

public interface IBooksRepository
{
    Task<Guid> Create(Book book);
    Task<Guid> Delete(Guid id);
    Task<List<Book>> Get();
    Task<Guid> Update(Guid id, string title, string description, decimal price);
}