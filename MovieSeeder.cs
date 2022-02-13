using ManageMovies.Entities;

namespace ManageMovies
{
    public class MovieSeeder
    {
        private readonly MovieDbContext _dbContext;
        public MovieSeeder(MovieDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Movies.Any())
                {
                    var movies = GetMovies();
                    _dbContext.Movies.AddRange(movies);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Name = "The Silence of the Lambs",
                    Year = 1991
                },
                new Movie()
                {
                    Name = "Titanic",
                    Year = 1997
                }
            };
            return movies;
        }
    }
}
