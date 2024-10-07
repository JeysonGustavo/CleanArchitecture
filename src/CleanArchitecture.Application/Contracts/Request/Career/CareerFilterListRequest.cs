using CleanArchitecture.Application.Common.Contracts.Request;

namespace CleanArchitecture.Application.Contracts.Request.Career
{
    public class CareerFilterListRequest : PaginationRequest
    {
        public string Language { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime? LastModifiedOnFrom { get; set; }
        public DateTime? LastModifiedOnTo { get; set; }
    }
}