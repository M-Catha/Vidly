using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _DBContext;

        public MoviesController()
        {
            _DBContext = new ApplicationDbContext();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _DBContext.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            };

            var movieDTOs = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(movieDTOs);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovieById (int id)
        {
            var movie = _DBContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return NotFound();

            var movieDTO = Mapper.Map<Movie, MovieDTO>(movie);

            return Ok(movieDTO);
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO) 
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _DBContext.Movies.Add(movie);
            _DBContext.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        // PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie (int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var existingMovie = _DBContext.Movies.SingleOrDefault(m => m.Id == id);

            if (existingMovie == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDTO, existingMovie);

            _DBContext.SaveChanges();
        }

        // DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie (int id)
        {
            var existingMovie = _DBContext.Movies.SingleOrDefault(m => m.Id == id);

            if (existingMovie == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _DBContext.Movies.Remove(existingMovie);
            _DBContext.SaveChanges();
        }

    }
}
