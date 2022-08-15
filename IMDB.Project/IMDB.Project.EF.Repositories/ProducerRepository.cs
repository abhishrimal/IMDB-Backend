using IMDB.Project.EF.DB;
using IMDB.Project.EF.Repositories.Interfaces;

namespace IMDB.Project.EF.Repositories
{
    public class ProducerRepository: IProducerRepository
    {
        private readonly IMDBContext iMDBContext;
        public ProducerRepository(IMDBContext _iMDBContext)
        {
            iMDBContext=_iMDBContext;
        }

        public bool AddProducer(Producer producer)
        {
            try
            {
                iMDBContext?.Producers?.Add(producer);
                iMDBContext?.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Producer> GetAllProducers()
        {
            var producerList = iMDBContext?.Producers?.AsEnumerable();
            return producerList;
        }

        public Producer GetProducerById(int producerId)
        {
            var producer = iMDBContext?.Producers?.FirstOrDefault(x => x.ProducerId == producerId);
            return producer;
        }

        public bool RemoveProducer(int producerId)
        {
            var producer = GetProducerById(producerId);
            if(producer != null)
            {
                iMDBContext?.Producers?.Remove(producer);
                iMDBContext?.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }    
        }

        public Producer UpdateProducer(Producer producer)
        {
            throw new NotImplementedException();
        }
    }
}
