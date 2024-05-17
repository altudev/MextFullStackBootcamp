using MextFullStack.Persistence.Services;
using MextFullStack.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootPathsController : ControllerBase
    {
       private readonly IRootPathService _rootPathService;

       public RootPathsController(IRootPathService rootPathService)
       {
           _rootPathService = rootPathService;
       }

       [HttpGet]
        public IActionResult GetRootPath()
        {
            return Ok(_rootPathService.GetRootPath());
        }

        [HttpPost]
        public IActionResult SaveCountsToRootPath()
        {
            _rootPathService.WriteTotalCount();

            return Ok("Total Counts have been successfully written.");
        }
    }
}
