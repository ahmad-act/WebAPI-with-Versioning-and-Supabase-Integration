using BookInformationService.Models;
using Microsoft.EntityFrameworkCore;


/* Ensure Migration and Database Initialization:

Open Package Manager Console:
Navigate to Tools > NuGet Package Manager > Package Manager Console in Visual Studio.

Execute the following command:
    Add-Migration InitialCreate
    Update-Database

*/

namespace BookInformationService.DatabaseContext
{
    public class SystemDbContext : DbContext
    {
        public DbSet<BookInformation> BookInformations { get; set; }

        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Ignore<ReservedBookInfo>();
            //modelBuilder.Ignore<ReservationHistory>();

            modelBuilder.Entity<BookInformation>()
           .HasKey(b => b.Id);

            modelBuilder.Entity<BookInformation>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd(); // Ensure that Id is auto-generated

            // Configure unique constraint on Title
            modelBuilder.Entity<BookInformation>()
                    .HasIndex(b => b.Title)
                    .IsUnique();
        }
    }
}
