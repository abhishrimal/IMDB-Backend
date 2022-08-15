using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;
using IMDB.Project.Services.Interface;

namespace IMDB.Project.Services
{
    public class PosterService : IPosterService
    {
        private readonly IPosterRepository posterRepository;
        public PosterService(IPosterRepository _posterRepository)
        {
            posterRepository = _posterRepository;
        }
        public Task<IEnumerable<Poster>> GetAllPosters()
        {
            return Task.FromResult(posterRepository.GetAllPosters());
        }

        public Task<Poster> GetPosterById(int genderId)
        {
            return Task.FromResult(posterRepository.GetPosterById(genderId));
        }
    }
}
