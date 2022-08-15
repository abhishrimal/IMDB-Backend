using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;
using IMDB.Project.Services.Interface;

namespace IMDB.Project.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository actorRepository;
        public ActorService(IActorRepository _actorRepository)
        {
            actorRepository= _actorRepository;
        }

        public Task<bool> AddActor(Actor actor)
        {
           return Task.FromResult(actorRepository.AddActor(actor));
        }

        public Task<Actor> GetActorById(int actorId)
        {
            return Task.FromResult(actorRepository.GetActorById(actorId));
        }

        public Task<IEnumerable<Actor>> GetAllActors()
        {
            return Task.FromResult(actorRepository.GetAllActors());
        }
    }
}