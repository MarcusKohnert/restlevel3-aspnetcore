using Microsoft.AspNetCore.Mvc;
using System;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoryItemPostController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get([FromBody] RepositoryRequestRepresentation repository)
        {
            var id = DateTime.Now.Second;

            var repo = new RepositoryItemRepresentation
            {
                Id   = id,
                Name = repository.Name,
            };

            return this.Created($"/repositories/{id}", repo);
        }
    }
}