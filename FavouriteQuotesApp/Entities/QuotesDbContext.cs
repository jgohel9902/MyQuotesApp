using Microsoft.EntityFrameworkCore;

namespace FavouriteQuotesApp.Entities
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>().HasData(
                 new Quote { Id = 1, Text = "To be or not to be", Author = "Shakespeare", Rating = 5, Description = "Famous" },
                 new Quote { Id = 2, Text = "You have to slow down to move fast", Author = "Anonymous", Rating = 4, Description = "Wise" }
             );
        }
    }
}
