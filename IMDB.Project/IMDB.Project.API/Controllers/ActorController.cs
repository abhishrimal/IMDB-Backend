using IMDB.Project.EF.DB;
using IMDB.Project.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.Project.API.Controllers
{
    [ApiController]
    public class ActorController : Controller
    {
        private readonly IActorService actorService;
        public ActorController(IActorService _actorService)
        {
            actorService = _actorService;
        }
        [HttpPost]
        [Route("addActor")]
        [ApiVersion("1")]
        public bool AddActor([FromBody]Actor actor)
        {
            var addActorResult=actorService.AddActor(actor);
            return addActorResult.Result;
        }
    }
}
