using IMDB.Project.EF.DB;

namespace IMDB.Project.EF.Repositories.Interfaces
{
    public interface IActorRepository
    {
        public bool AddActor(Actor actor);
        public bool RemoveActor(int actorId);
        public Actor GetActorById(int actorId);
        public IEnumerable<Actor> GetAllActors();
        public Actor UpdateActor(Actor actor);

    }
}
