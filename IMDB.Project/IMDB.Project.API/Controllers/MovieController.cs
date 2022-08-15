using IMDB.Project.EF.DB.ApiModel;
using IMDB.Project.Services.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Project.API.Controllers
{
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IActorMovieMappingsService actorMovieMappingsService;
        public MovieController(IMovieService _movieService, IActorMovieMappingsService _actorMovieMappingsService)
        {
            movieService = _movieService;
            actorMovieMappingsService = _actorMovieMappingsService;
        }
       
        [HttpGet]
        [Route("home")]
        [ApiVersion("1")]
        public IEnumerable<MovieHomePage> GetMovieHomePage()
        {
            var homePage= movieService.GetMovieHomePage().Result;
            return homePage;
        }
        [HttpPost]
        [Route("home/addMovie")]
        [ApiVersion("1")]
        public bool AddMovie([FromBody]EF.DB.ApiModel.Movies movie)
        {
            List<int> actorIds = new List<int>();
            foreach(var id in movie.ActorIds)
            {
                actorIds.Add(id);
            }
            var addMovie = movie.Adapt<EF.DB.Movie>();
            var movieAddResult=movieService.AddMovie(addMovie);
            actorMovieMappingsService.AddActorMovieMappings(actorIds, addMovie.MovieId);
            return movieAddResult.Result;
        }
        [HttpPut]
        [Route("home/updateMovie")]
        [ApiVersion("1")]
        public bool UpdateMovie([FromBody]EF.DB.ApiModel.Movies movie)
        {
            List<int> actorIds = new List<int>();
            foreach (var id in movie.ActorIds)
            {
                actorIds.Add(id);
            }
            var movieUpdateResult = movieService.EditMovie(movie.Adapt<EF.DB.Movie>(),actorIds);
            return movieUpdateResult.Result;

        }
    }
}
