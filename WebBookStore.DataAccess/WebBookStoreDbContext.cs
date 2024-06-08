using Microsoft.EntityFrameworkCore;
using WebBookStore.DataAccess.Entites;

namespace WebBookStore.DataAccess;

public class WebBookStoreDbContext : DbContext
{
    public WebBookStoreDbContext(DbContextOptions<WebBookStoreDbContext> options) : base (options)
    {
        
    }

    public DbSet<BookEntity> Books { get; set; }
}