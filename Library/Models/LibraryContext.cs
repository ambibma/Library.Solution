using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Patron> Patrons { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemProperty> ItemProperties { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}