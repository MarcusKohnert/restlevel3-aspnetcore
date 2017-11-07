using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoryItemDeleteController : ControllerBase
    {
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var authorizationHeader = this.Request.Headers["Authorization"];
            if (authorizationHeader.Any(_ => _.Equals("Admin", StringComparison.OrdinalIgnoreCase)))
            {
                // delete in peristence or mark deleted
                return this.NoContent();
            }

            return this.BadRequest();
        }
    }
}