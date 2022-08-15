using IMDB.Project.EF.DB;

namespace IMDB.Project.EF.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        public bool AddMovie(Movie movie);
        public bool RemoveMovie(int movieId);
        public Movie GetMovieById(int movieId);
        public IEnumerable<Movie> GetAllMovie();
        public bool UpdateMovie(Movie movie);
    }
}
