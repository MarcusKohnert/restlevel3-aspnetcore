using Halcyon.HAL;
using System;

namespace restlevel3aspnetcore.Controllers.Repositories
{
    public class ContributorListRepresentation
    {
        public ContributorListRepresentation()
        {
            this.List = Array.Empty<HALResponse>();
        }

        public int Total => this.List.Length;

        public HALResponse[] List { get; set; }
    }
}