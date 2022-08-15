using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;
using IMDB.Project.Services.Interface;

namespace IMDB.Project.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository producerRepository;
        public ProducerService(IProducerRepository _producerRepository)
        {
            producerRepository = _producerRepository;
        }
        public Task<bool> AddProducer(Producer producer)
        {
            return Task.FromResult(producerRepository.AddProducer(producer));
        }

        public Task<IEnumerable<Producer>> GetAllProducers()
        {
            return Task.FromResult(producerRepository.GetAllProducers());
        }

        public Task<Producer> GetProducerById(int producerId)
        {
            return Task.FromResult(producerRepository.GetProducerById(producerId));
        }
    }
}
