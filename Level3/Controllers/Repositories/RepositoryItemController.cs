using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
                ).AddLinks(this.GetLinks(id))
            );
        }

        private IEnumerable<Link> GetLinks(int id)
        {
            yield return new Link(Link.RelForSelf, $"/repositories/{id}");

            yield return new Link("repository-contributors", $"/repositories/{id}/contributors");

            var authorizationHeader = this.Request.Headers["Authorization"];

            if (authorizationHeader.Any(_ => _.Equals("Contributor", StringComparison.OrdinalIgnoreCase) ||
                                             _.Equals("Admin", StringComparison.OrdinalIgnoreCase)))
            {
                yield return new Link("repository-edit", $"/repositories/{id}", "Edit", "PUT");
            }

            if (authorizationHeader.Any(_ => _.Equals("Admin", StringComparison.OrdinalIgnoreCase)))
            {
                yield return new Link("repository-deletion", $"/repositories/{id}", "Delete", "DELETE");
            }
        }
    }
}