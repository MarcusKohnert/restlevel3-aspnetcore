using Halcyon.HAL;
using System;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    public class RepositoryListRepresentation
    {
        public RepositoryListRepresentation()
        {
            this.List = Array.Empty<HALResponse>();
        }

        public int Total => this.List.Length;

        public HALResponse[] List { get; set; }
    }
}