using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoryItemPutController : ControllerBase
    {
        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, [FromBody] RepositoryRequestRepresentation repositoryRequest)
        {
            var authorizationHeader = this.Request.Headers["Authorization"];
            if (authorizationHeader.Any(_ => _.Equals("Contributor", StringComparison.OrdinalIgnoreCase) || 
                                             _.Equals("Admin", StringComparison.OrdinalIgnoreCase)))
            {
                return this.HAL(
                    new HALResponse(
                        new RepositoryItemRepresentation
                        {
                            Id   = id,
                            Name = repositoryRequest.Name,
                        })
                    .AddLinks(new Link(Link.RelForSelf, $"/repositories/{id}"))
                );
            }

            return this.BadRequest();
        }
    }
}