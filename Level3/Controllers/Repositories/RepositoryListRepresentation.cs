using System.Collections.Generic;
using System.Linq;
using Halcyon.HAL;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    public class RepositoryListRepresentation
    {
        public RepositoryListRepresentation()
        {
            this.List = Enumerable.Empty<HALResponse>();
        }

        public int Total => this.List.Count();

        public IEnumerable<HALResponse> List { get; set; }
    }
}