using Microsoft.EntityFrameworkCore;

namespace ManageMovies.Entities
{
    public class MovieDbContext :DbContext
    {
        private string _connnectionString = "Server=DESKTOP-P46VLN4\\SQLEXPRESS;Database=MovieDb;Trusted_Connection=True;";
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connnectionString);
        }
    }
}
