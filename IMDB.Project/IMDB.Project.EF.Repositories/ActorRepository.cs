using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;

namespace IMDB.Project.EF.Repositories
{
    public class ActorRepository: IActorRepository
    {
        private readonly IMDBContext iMDBContext;
        public ActorRepository(IMDBContext _iMDBContext)
        {
            iMDBContext= _iMDBContext;
        }

        public bool AddActor(Actor actor)
        {
            if (actor != null)
            {
                iMDBContext?.Actors?.Add(actor);
                iMDBContext?.SaveChanges();
                return true;
            }
           else
            {
                return false;
            }
        }

        public Actor GetActorById(int actorId)
        {
            var actor = iMDBContext?.Actors?.FirstOrDefault(x => x.ActorId == actorId);
            return actor;
        }

        public IEnumerable<Actor> GetAllActors()
        {
            var actorList= iMDBContext?.Actors?.AsEnumerable();
            return actorList;
        }

        public bool RemoveActor(int actorId)
        {
            var actor= iMDBContext?.Actors?.FirstOrDefault(x => x.ActorId == actorId);
            if(actor !=null)
            {
                iMDBContext?.Remove(actor);
                iMDBContext?.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Actor UpdateActor(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
