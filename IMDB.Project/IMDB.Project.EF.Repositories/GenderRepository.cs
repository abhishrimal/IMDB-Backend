using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;

namespace IMDB.Project.EF.Repositories
{
    public class GenderRepository:IGenderRepository
    {
        private readonly IMDBContext iMDBContext;
        public GenderRepository(IMDBContext _iMDBContext)
        {
            iMDBContext=_iMDBContext;
        }
        public bool AddGender(Gender gender)
        {
            try
            {
                iMDBContext.Genders.Add(gender);
                iMDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Gender> GetAllGenders()
        {
            var genderList = iMDBContext?.Genders?.AsEnumerable();
            return genderList;
        }

        public Gender GetGenderById(int genderId)
        {
            var gender = iMDBContext?.Genders?.FirstOrDefault(x => x.GenderId == genderId);
            return gender;
        }

        public bool RemoveGender(int genderId)
        {
            var gender= GetGenderById(genderId);
            if(gender!=null)
            {
                iMDBContext.Genders.Remove(gender);
                iMDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Gender UpdateGender(Gender gender)
        {
            throw new NotImplementedException();
        }
    }
}
