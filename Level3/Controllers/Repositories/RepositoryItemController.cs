using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoryItemController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return this.HAL(
                new HALResponse(
                    new RepositoryItemRepresentation
                    {
                        Id           = id,
                        Name         = "Repo " + id,
                        Contributors = new [] { "Contributor 1", "Contributor 2", "Contributor 3" },
                        Languages    = new [] { "C#, PowerShell, F#" }
                    }
                ).AddLinks(
                    new Link(Link.RelForSelf, $"/repositories/{id}")
                )
            );
        }
    }
}