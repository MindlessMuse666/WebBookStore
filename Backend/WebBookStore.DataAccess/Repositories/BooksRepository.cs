﻿using WebBookStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using WebBookStore.Core.Abstractions.Interfaces;
using WebBookStore.DataAccess.Entites;

namespace WebBookStore.DataAccess.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly WebBookStoreDbContext _context;

    public BooksRepository(WebBookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> Get()
    {
        var bookEntities = await _context.Books
            .AsTracking()
            .ToListAsync();

        var books = bookEntities
            .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book)
            .ToList();

        return books;
    }

    public async Task<Guid> Create(Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Price = book.Price
        };

        await _context.Books.AddAsync(bookEntity);
        await _context.SaveChangesAsync();

        return bookEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description, decimal price)
    {
        await _context.Books
            .Where(b => b.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Title, b => title)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Price, b => price));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Books
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}