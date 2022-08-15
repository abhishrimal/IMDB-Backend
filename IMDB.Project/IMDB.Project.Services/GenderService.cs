using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;
using IMDB.Project.Services.Interface;

namespace IMDB.Project.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository genderRepository;
        public GenderService(IGenderRepository _genderRepository)
        {
            genderRepository= _genderRepository;
        }
        public Task<IEnumerable<Gender>> GetAllGenders()
        {
            return Task.FromResult(genderRepository.GetAllGenders());
        }

        public Task<Gender> GetGenderById(int genderId)
        {
            return Task.FromResult(genderRepository.GetGenderById(genderId));
        }
    }
}
