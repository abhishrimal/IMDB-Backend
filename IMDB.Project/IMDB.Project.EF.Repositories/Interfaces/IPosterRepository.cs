using IMDB.Project.EF.DB;

namespace IMDB.Project.EF.Repositories.Interfaces
{
    public interface IPosterRepository
    {
        public bool AddPoster(Poster  poster);
        public bool RemovePoster(int posterId);
        public Poster GetPosterById(int posterId);
        public IEnumerable<Poster> GetAllPosters();
        public Poster UpdatePoster(Poster poster);
    }
}
