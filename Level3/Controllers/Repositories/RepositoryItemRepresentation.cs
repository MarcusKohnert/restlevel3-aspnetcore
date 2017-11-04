namespace restlevel3aspnetcore.Controllers.Repositories
{
    public class RepositoryItemRepresentation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] Contributors { get; set; }

        public string[] Languages { get; set; }
    }
}