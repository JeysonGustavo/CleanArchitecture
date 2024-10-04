namespace CleanArchitecture.Application.Contracts.Request.Common
{
    public class PaginationRequest
    {
        public int PageSize { get; set; }
        public int StartSelection { get; set; }
    }
}
