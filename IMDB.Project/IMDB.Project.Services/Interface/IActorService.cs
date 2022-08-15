using IMDB.Project.EF.DB;

namespace IMDB.Project.Services.Interface
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetAllActors();
        public Task<Actor> GetActorById(int actorId);
        public Task<bool> AddActor(Actor actor);

    }
}
