using AutoMapper;
using MovieAPI.Entities;
using MovieAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Services
{
    public interface IMovieService
    {
        int Create(CreateMovieDto dto);
        IEnumerable<MovieDto> GetAll();
        MovieDto GetById(int id);
        bool Delete(int id);
        bool Update(int id, UpdateMovieDto dto);
    }
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieService(MovieDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
        public MovieDto GetById(int id)
        {
            var movie = _dbContext
                .Movies
                .FirstOrDefault(m => m.Id == id);
            if (movie is null)
            {
                return null;
            }
            var result = _mapper.Map<MovieDto>(movie);
            return result;
        }

        public IEnumerable<MovieDto> GetAll()
        {
            var movies = _dbContext
                .Movies
                .ToList();

            var moviesDtos = _mapper.Map<List<MovieDto>>(movies);

            return moviesDtos;
        }
        public int Create(CreateMovieDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie.Id;
        }

        public bool Delete(int id)
        {
            var movie = _dbContext
                .Movies
                .FirstOrDefault(m => m.Id == id);

            if(movie is null)
            {
                return false;
            }
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdateMovieDto dto)
        {
            var movie = _dbContext
                .Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie is null)
            {
                return false;
            }
            movie.Name = dto.Name;
            movie.Year = dto.Year;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
