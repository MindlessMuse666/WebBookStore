using WebBookStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBookStore.DataAccess.Entites;

namespace WebBookStore.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Title)
            .HasMaxLength(Book.MAX_TITLE_LENGTH)
            .IsRequired();

        builder.Property(b => b.Description)
            .IsRequired();

        builder.Property(b => b.Price)
            .IsRequired();
    }
}