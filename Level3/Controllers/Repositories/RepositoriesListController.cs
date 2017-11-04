using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoriesListController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.HAL(
                new HALResponse(
                    new RepositoryListRepresentation
                    {
                        List = 
                            Enumerable
                            .Range(1, 3)
                            .Select(_ =>
                                new HALResponse(
                                    new RepositoryListItemRepresentation
                                    {
                                        Id   = _,
                                        Name = $"Repo {_}"
                                    }).AddLinks(
                                    new Link(
                                        Link.RelForSelf, $"/repositories/{_}", $"Repo {_}")
                                    )
                            )
                            .ToArray()
                    }
                ).AddLinks(this.GetLinks())
            );
        }

        private IEnumerable<Link> GetLinks()
        {
            yield return new Link(Link.RelForSelf, "/repositories", "Repositories");

            yield return new Link("repository-creation", "/repositories", "New Repository", "POST");
        }
    }
}