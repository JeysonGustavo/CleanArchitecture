namespace CleanArchitecture.Application.Contracts.Response.Career
{
    public class CareerResponse
    {
        public int Id { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Introduction { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int TotalRecords { get; set; }
    }
}
