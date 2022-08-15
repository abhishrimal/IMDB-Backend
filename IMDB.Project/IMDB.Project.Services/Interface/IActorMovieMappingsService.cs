using IMDB.Project.EF.DB;

namespace IMDB.Project.Services.Interface
{
    public interface IActorMovieMappingsService
    {
        public Task<ActorMovieMapping> GetActorMovieMappingById(int actorMovieMappingId);
        public Task<IEnumerable<ActorMovieMapping>> GetActorMovieMappingByMovieId(int movieId);
        public Task<IEnumerable<ActorMovieMapping>> GetAllActorMovieMappings();
        public bool AddActorMovieMappings(List<int> actorId, int movieId);
        public Task<bool> DeleteActorMovieMapping(int actorId, int movieId);
    }
}
