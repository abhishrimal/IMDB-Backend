using IMDB.Project.EF.DB;

namespace IMDB.Project.Services.Interface
{
    public interface IProducerService
    {
        public Task<IEnumerable<Producer>> GetAllProducers();
        public Task<Producer> GetProducerById(int producerId);
        public Task<bool> AddProducer(Producer producer);
    }
}
