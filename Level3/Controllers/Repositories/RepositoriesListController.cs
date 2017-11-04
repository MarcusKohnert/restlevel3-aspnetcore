using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoriesListController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.HAL(
                new HALResponse(
                    new RepositoryListRepresentation
                    {
                        List = new []
                        {
                            new HALResponse(
                                new RepositoryListItemRepresentation
                                {
                                    Id   = 1,
                                    Name = "Repo 1"
                                }).AddLinks(
                                    new Link(Link.RelForSelf, "/repositories/1", "Repo 1")
                                ),
                            new HALResponse(
                                new RepositoryListItemRepresentation
                                {
                                    Id   = 2,
                                    Name = "Repo 2"
                                }).AddLinks(
                                new Link(
                                    Link.RelForSelf, "/repositories/2", "Repo 2")
                                ),
                            new HALResponse(
                                new RepositoryListItemRepresentation
                                {
                                    Id   = 3,
                                    Name = "Repo 3"
                                }).AddLinks(
                                    new Link(Link.RelForSelf, "/repositories/3", "Repo 3")
                                )
                        }
                    }
                ).AddLinks(
                    new Link(Link.RelForSelf, "/repositories", "Repositories")
                )
            );
        }
    }
}