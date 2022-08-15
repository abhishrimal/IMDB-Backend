using IMDB.Project.EF.DB;
using IMDB.Project.EF.DB.ApiModel;

namespace IMDB.Project.Services.Interface
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetAllMovies();
        public Task<Movie> GetMovieById(int movieId);
        public Task<bool> AddMovie(Movie movie);
        public Task<bool> EditMovie(Movie movie,List<int> actorIds);
        public Task<List<MovieHomePage>> GetMovieHomePage();
    }
}
