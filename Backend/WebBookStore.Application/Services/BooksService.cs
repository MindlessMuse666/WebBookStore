using WebBookStore.Core.Abstractions.Interfaces;
using WebBookStore.Core.Models;

namespace WebBookStore.Application.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<List<Book>> GetAllBooks() =>
        await _booksRepository.Get();

    public async Task<Guid> CreateBook(Book book) =>
        await _booksRepository.Create(book);

    public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price) =>
        await _booksRepository.Update(id, title, description, price);

    public async Task<Guid> DeleteBook(Guid id) =>
        await _booksRepository.Delete(id);
}