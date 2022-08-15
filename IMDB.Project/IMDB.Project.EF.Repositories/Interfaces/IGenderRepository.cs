using IMDB.Project.EF.DB;

namespace IMDB.Project.EF.Repositories.Interfaces
{
    public interface IGenderRepository
    {
        public bool AddGender(Gender gender);
        public bool RemoveGender(int genderId);
        public Gender GetGenderById(int genderId);
        public IEnumerable<Gender> GetAllGenders();
        public Gender UpdateGender(Gender gender);

    }
}
