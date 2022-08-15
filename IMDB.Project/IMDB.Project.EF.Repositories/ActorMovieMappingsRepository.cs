using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;

namespace IMDB.Project.EF.Repositories
{
    public class ActorMovieMappingsRepository: IActorMovieMappingsRepository
    {
        public readonly IMDBContext iMDBContext;
        public ActorMovieMappingsRepository(IMDBContext _iMDBContext)
        {
            iMDBContext=_iMDBContext;
        }

        public bool AddActorMovieMapping(ActorMovieMapping actorMovieMapping)
        {
            if (actorMovieMapping != null)
            {
                iMDBContext.ActorMovieMappings.Add(actorMovieMapping);
                iMDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteMappingByActorId(int actorId,int movieId)
        {
            var actorMovieMapping = iMDBContext.ActorMovieMappings.FirstOrDefault(x => x.MovieId == movieId && x.ActorId == actorId);
            if(actorMovieMapping!=null)
            {
                iMDBContext.ActorMovieMappings.Remove(actorMovieMapping);
                iMDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }        

        public ActorMovieMapping GetActorMovieMappingById(int actorMovieMappingId)
        {
            var actorMovieMapping = iMDBContext?.ActorMovieMappings?.FirstOrDefault(x => x.ActorMovieMappingId == actorMovieMappingId);
            return actorMovieMapping;
        }

        public IEnumerable<ActorMovieMapping> GetAllActorMovieMappings()
        {
            return iMDBContext.ActorMovieMappings.AsEnumerable();
        }

        public IEnumerable<ActorMovieMapping> GetAllActorMovieMappingsByMovieId(int movieId)
        {
            var actorMovieMappings = iMDBContext?.ActorMovieMappings?.Where(x => x.MovieId == movieId).AsEnumerable();
            return actorMovieMappings;
        }

        public bool RemoveActorMovieMapping(int actorMovieMappingId)
        {
            var mapping = GetActorMovieMappingById(actorMovieMappingId);
            if(mapping!=null)
            {
                iMDBContext.ActorMovieMappings.Remove(mapping);
                iMDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActorMovieMapping UpdateActorMovieMapping(ActorMovieMapping actorMovieMapping)
        {
            throw new NotImplementedException();
        }
    }
}
