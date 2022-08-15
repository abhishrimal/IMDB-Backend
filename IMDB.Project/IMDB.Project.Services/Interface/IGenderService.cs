using IMDB.Project.EF.DB;

namespace IMDB.Project.Services.Interface
{
    public interface IGenderService
    {
        public Task<IEnumerable<Gender>> GetAllGenders();
        public Task<Gender> GetGenderById(int genderId);
    }
}
