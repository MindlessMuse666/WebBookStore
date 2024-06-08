using Microsoft.AspNetCore.Mvc;
using WebBookStore.API.Contracts;
using WebBookStore.Application.Services;
using WebBookStore.Core.Models;

namespace WebBookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BooksResponce>>> GetBooks()
    {
        var books = await _booksService.GetAllBooks();
        var responce = books
            .Select(b => new BooksResponce(b.Id, b.Title, b.Description, b.Price));

        return Ok(responce);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
    {
        var (book, error) = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.Price);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var bookId = await _booksService.CreateBook(book);

        return Ok(bookId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest request)
    {
        var bookId = await _booksService.UpdateBook(
            id, request.Title, request.Description, request.Price);

        return Ok(bookId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {
        var bookId = await _booksService.DeleteBook(id);

        return Ok(bookId);
    }
}