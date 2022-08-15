using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;
using IMDB.Project.Services.Interface;

namespace IMDB.Project.Services
{
    public class ActorMovieMappingsService : IActorMovieMappingsService
    {
        private readonly IActorMovieMappingsRepository actorMovieMappingsRepository;
        public ActorMovieMappingsService(IActorMovieMappingsRepository _actorMovieMappingsRepository)
        {
            actorMovieMappingsRepository = _actorMovieMappingsRepository;
        }

        public bool AddActorMovieMappings(List<int> actorId,int movieId)
        {
            if (actorId.Count() > 0)
            {
                foreach (var id in actorId)
                {
                    ActorMovieMapping actorMovieMapping = new ActorMovieMapping();
                    actorMovieMapping.ActorId = id;
                    actorMovieMapping.MovieId = movieId;
                    actorMovieMappingsRepository.AddActorMovieMapping(actorMovieMapping);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> DeleteActorMovieMapping(int actorID, int movieId)
        {
            return Task.FromResult(actorMovieMappingsRepository.DeleteMappingByActorId(actorID,movieId));
        }

        public Task<ActorMovieMapping> GetActorMovieMappingById(int actorMovieMappingId)
        {
            return Task.FromResult(actorMovieMappingsRepository.GetActorMovieMappingById(actorMovieMappingId));
        }

        public Task<IEnumerable<ActorMovieMapping>> GetActorMovieMappingByMovieId(int movieId)
        {
            return Task.FromResult(actorMovieMappingsRepository.GetAllActorMovieMappingsByMovieId(movieId));
        }

        public Task<IEnumerable<ActorMovieMapping>> GetAllActorMovieMappings()
        {
            return Task.FromResult(actorMovieMappingsRepository.GetAllActorMovieMappings());
        }
    }
}
