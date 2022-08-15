using IMDB.Project.EF.DB;
using IMDB.Project.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Project.API.Controllers
{
    [ApiController]
    public class ProducerController : Controller
    {
        private readonly IProducerService producerService;
        public ProducerController(IProducerService _producerService)
        {
            producerService = _producerService;
        }
        [HttpPost]
        [Route("addProducer")]
        [ApiVersion("1")]
        public bool AddProducer([FromBody]Producer producer)
        {
            var addProducerResult= producerService.AddProducer(producer);
            return addProducerResult.Result;
        }
    }
}
