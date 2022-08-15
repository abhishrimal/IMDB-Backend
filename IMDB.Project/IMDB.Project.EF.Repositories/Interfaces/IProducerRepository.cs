using IMDB.Project.EF.DB;

namespace IMDB.Project.EF.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        public bool AddProducer(Producer producer);
        public bool RemoveProducer(int producerId);
        public Producer GetProducerById(int producerId);
        public IEnumerable<Producer> GetAllProducers();
        public Producer UpdateProducer(Producer producer);
    }
}
