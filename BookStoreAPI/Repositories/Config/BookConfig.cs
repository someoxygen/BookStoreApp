using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace BookStoreAPI.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Price = 10.99M },
                new Book { Id = 2, Title = "1984", Price = 8.99M },
                new Book { Id = 3, Title = "To Kill a Mockingbird", Price = 12.49M },
                new Book { Id = 4, Title = "Pride and Prejudice", Price = 9.99M },
                new Book { Id = 5, Title = "The Catcher in the Rye", Price = 11.50M }
            );
        }
    }
}
