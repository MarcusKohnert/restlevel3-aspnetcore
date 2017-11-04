using Microsoft.AspNetCore.Mvc;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    [Route("repositories")]
    public class RepositoryItemDeleteController : ControllerBase
    {
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id) => this.NoContent();
    }
}