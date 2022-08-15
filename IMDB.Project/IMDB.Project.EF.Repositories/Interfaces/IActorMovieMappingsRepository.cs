using IMDB.Project.EF.DB;

namespace IMDB.Project.EF.Repositories.Interfaces
{
    public interface IActorMovieMappingsRepository
    {
        public bool AddActorMovieMapping(ActorMovieMapping actorMovieMapping);
        public bool RemoveActorMovieMapping(int actorMovieMappingId);
        public ActorMovieMapping GetActorMovieMappingById(int actorMovieMappingId);
        public IEnumerable<ActorMovieMapping> GetAllActorMovieMappingsByMovieId(int movieId);
        public IEnumerable<ActorMovieMapping> GetAllActorMovieMappings();
        public ActorMovieMapping UpdateActorMovieMapping(ActorMovieMapping actorMovieMapping);
        public bool DeleteMappingByActorId(int actorId,int movieId);
    }
}
