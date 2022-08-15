using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;

namespace IMDB.Project.EF.Repositories
{
    public class MovieRepository:IMovieRepository
    {
        private readonly IMDBContext iMDBContext;
        public MovieRepository(IMDBContext _iMDBContext)
        {
            iMDBContext= _iMDBContext;
        }

        public bool AddMovie(Movie movie)
        {
            try
            {
                iMDBContext?.Movies?.Add(movie);
                iMDBContext?.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Movie> GetAllMovie()
        {
            var movieList = iMDBContext?.Movies?.AsEnumerable();
            return movieList;
        }

        public Movie GetMovieById(int movieId)
        {
            var movie = iMDBContext?.Movies?.FirstOrDefault(x => x.MovieId == movieId);
            return movie;
        }

        public bool RemoveMovie(int movieId)
        {
            var movie=GetMovieById(movieId);
            if (movie != null)
            {
                iMDBContext.Movies.Remove(movie);
                iMDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateMovie(Movie movie)
        {
            var movieExists = GetMovieById(movie.MovieId);
            if(movieExists!=null)
            {
                movieExists.MovieName = movie.MovieName;
                movieExists.Plot = movie.Plot;
                movieExists.DateOfRelease = movie.DateOfRelease;
                movieExists.ProducerId = movie.ProducerId;
                movieExists.PosterId = movie.PosterId;
                movieExists.UpdatedOn=DateTime.Now;
                iMDBContext.Entry(movieExists).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                iMDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
