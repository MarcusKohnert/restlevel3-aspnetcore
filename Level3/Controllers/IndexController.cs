using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;

namespace restlevel3aspnetcore.Controllers
{
    [Route("")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return
                this.HAL(
                    new HALResponse(null)
                    .AddLinks(
                        new Link(Link.RelForSelf, "/", "Index"),
                        new Link("repositories", "/repositories", "Repositories")
                    )
                );
        }
    }
}