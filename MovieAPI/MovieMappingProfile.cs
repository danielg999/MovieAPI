using AutoMapper;
using MovieAPI.Entities;
using MovieAPI.Models;

namespace MovieAPI
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>();

            CreateMap<CreateMovieDto, Movie>();
        }
    }
}
