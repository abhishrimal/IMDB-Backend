using IMDB.Project.EF.DB;
using IMDB.Project.EF.DB.ApiModel;
using IMDB.Project.EF.Repositories.Interfaces;
using IMDB.Project.Services.Interface;
using Mapster;

namespace IMDB.Project.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IActorService actorService;
        private readonly IProducerService producerService;
        private readonly IPosterService posterService;
        private readonly IActorMovieMappingsService actorMovieMappingsService;
        public MovieService(IMovieRepository _movieRepository,IActorService _actorService,IProducerService _producerService,IPosterService _posterService, IActorMovieMappingsService _actorMovieMappingsService)
        {
            movieRepository = _movieRepository;
            actorService= _actorService;
            producerService= _producerService;
            posterService = _posterService;
            actorMovieMappingsService = _actorMovieMappingsService;
        }

        public Task<bool> AddMovie(Movie movie)
        {
            return Task.FromResult(movieRepository.AddMovie(movie));
        }

        public async Task<bool> EditMovie(Movie movie,List<int> actorIds)
        {
            if (movie != null)
            {
                var mappings =await actorMovieMappingsService.GetActorMovieMappingByMovieId(movie.MovieId);
                var actorsIdsNotMapped = mappings.Where(x => !actorIds.Contains(x.ActorId)).Select(x => x.ActorId).ToList();
                foreach (var id in actorsIdsNotMapped)
                {
                    actorMovieMappingsService.DeleteActorMovieMapping(id, movie.MovieId);
                }
                var mappingsLeftToBeIncluded =await actorMovieMappingsService.GetActorMovieMappingByMovieId(movie.MovieId);

                List<int> actorIdsToBeIncluded = new List<int>();
                foreach (var actorId in actorIds)
                {
                    if(mappingsLeftToBeIncluded.Any(x=>x.ActorId!=actorId))
                    {
                        actorIdsToBeIncluded.Add(actorId);
                    }
                }

                actorMovieMappingsService.AddActorMovieMappings(actorIdsToBeIncluded, movie.MovieId);
                
            }
             return movieRepository.UpdateMovie(movie);
            
            
        }

        public Task<IEnumerable<Movie>> GetAllMovies()
        {
            return Task.FromResult(movieRepository.GetAllMovie());
        }

        public Task<Movie> GetMovieById(int movieId)
        {
            return Task.FromResult(movieRepository.GetMovieById(movieId));
        }

        public async Task<List<MovieHomePage>> GetMovieHomePage()
        {
            var tempMoviesList = await GetAllMovies();
            var moviesList = tempMoviesList.Adapt<List<MovieHomePage>>();
            var actors =await actorService.GetAllActors();
            var producers=await producerService.GetAllProducers();
            var mappings=await actorMovieMappingsService.GetAllActorMovieMappings();
            foreach(var movie in moviesList)
            {
                movie.ProducerName = producers?.FirstOrDefault(x => x?.ProducerId == movie.ProducerId)?.ProducerName;
                var poster = await posterService.GetPosterById(movie.PosterId);
                movie.DisplayPoster = poster.DisplayPoster;
                await GetAllActorsForMovie(movie);  
            }
            return moviesList;

        }
        private async Task<MovieHomePage> GetAllActorsForMovie(MovieHomePage movie)
        {
            var actorMovieMappings = await actorMovieMappingsService.GetActorMovieMappingByMovieId(movie.MovieId);
            foreach (var actorMovieMapping in actorMovieMappings)
            {
                var actor = await actorService?.GetActorById(actorMovieMapping.ActorId);
                if (actor != null)
                {
                    movie.Actors.Add(actor);
                }
            }
            return movie;
        }
    }
}
