using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;

namespace IMDB.Project.EF.Repositories
{
    public class PosterRepository: IPosterRepository
    {
        private readonly IMDBContext iMDBContext;
        public PosterRepository(IMDBContext _iMDBContext)
        {
            iMDBContext = _iMDBContext;
        }

        public bool AddPoster(Poster poster)
        {
            try
            {
                iMDBContext.Posters.Add(poster);
                iMDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Poster> GetAllPosters()
        {
            var posterList = iMDBContext?.Posters?.AsEnumerable();
            return posterList;
        }

        public Poster GetPosterById(int posterId)
        {
            var poster = iMDBContext?.Posters?.FirstOrDefault(x => x.PosterId == posterId);
            return poster;
        }

        public bool RemovePoster(int posterId)
        {
            var poster = GetPosterById(posterId);
            if (poster != null)
            {
                iMDBContext.Posters.Remove(poster);
                iMDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Poster UpdatePoster(Poster poster)
        {
            throw new NotImplementedException();
        }
    }

    }
