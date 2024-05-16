using MextFullStack.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootPathsController : ControllerBase
    {
        private readonly RootPathManager _rootPathManager;

        public RootPathsController(RootPathManager rootPathManager)
        {
            _rootPathManager = rootPathManager;
        }

        [HttpGet]
        public IActionResult GetRootPath()
        {
            return Ok(_rootPathManager.GetRootPath());
        }

        [HttpPost]
        public IActionResult SaveCountsToRootPath()
        {
            _rootPathManager.WriteTotalCount();

            return Ok("Total Counts have been successfully written.");
        }
    }
}
