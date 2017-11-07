using Halcyon.HAL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoryItemPostController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] RepositoryRequestRepresentation repository)
        {
            var id = DateTime.Now.Second;

            var response = new HALResponse(
                    new RepositoryItemRepresentation
                    {
                        Id   = id,
                        Name = repository.Name
                    })
                    .AddLinks(new Link(Link.RelForSelf, $"/repositories/{id}")
            );

            return this.Created($"/repositories/{id}", response);
        }
    }
}