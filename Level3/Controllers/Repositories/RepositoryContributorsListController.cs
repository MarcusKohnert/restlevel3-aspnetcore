using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoryContributorsListController : ControllerBase
    {
        [HttpGet("{id:int}/contributors")]
        public IActionResult Get(int id)
        {
            return this.HAL(
                new HALResponse(
                    new ContributorListRepresentation
                    {
                        List = 
                            Enumerable
                            .Range(1, 3)
                            .Select(_ =>
                                new HALResponse(
                                    new ContributorListItemRepresentation
                                    {
                                        Id         = _,
                                        GivenName  = $"Given {_}",
                                        FamilyName = $"Family {_}",

                                    }).AddLinks(
                                    new Link(
                                        Link.RelForSelf, $"/users/{_}", $"Contributor {_}")
                                    )
                            )
                            .ToArray()
                    }
                ).AddLinks(this.GetLinks(id))
            );
        }

        private IEnumerable<Link> GetLinks(int id)
        {
            yield return new Link(Link.RelForSelf, $"/repositories/{id}/contributors", "contributors");
        }
    }
}