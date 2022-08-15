using IMDB.Project.EF.DB;

namespace IMDB.Project.Services.Interface
{
    public interface IPosterService
    {
        public Task<IEnumerable<Poster>> GetAllPosters();
        public Task<Poster> GetPosterById(int genderId);
    }
}
