using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Entities;
using MovieAPI.Models;
using MovieAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Controlers
{
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {
            var moviesDtos = this._movieService.GetAll();

            return Ok(moviesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> Get([FromRoute] int id)
        {
            var movie = this._movieService.GetById(id);

            if(movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public ActionResult CreateMovie([FromBody] CreateMovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = this._movieService.Create(dto);

            return Created($"/api/movie/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = this._movieService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateMovieDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isUpdated = _movieService.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();

        }

    }
}
