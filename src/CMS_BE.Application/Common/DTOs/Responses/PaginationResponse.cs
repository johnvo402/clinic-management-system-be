namespace CMS_BE.Application.Common.DTOs.Responses
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T>? Data { get; private set; }

        public Paging<T>? Paging { get; private set; }

        public PaginationResponse(IEnumerable<T> data, int totalPage, int currentPage, int pageSize)
        {
            Data = data;
            Paging = new Paging<T>(totalPage, currentPage, pageSize);
        }

        public PaginationResponse(IEnumerable<T> data, int totalPage, int pageSize)
        {
            Data = data;
            Paging = new Paging<T>(totalPage, pageSize);
        }
    }

    public class Paging<T>
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }

        public bool? HasNextPage { get; set; }

        public bool? HasPreviousPage { get; set; }

        public Paging(int totalPage, int currentPage = 1, int pageSize = 10)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPage = totalPage;

            HasNextPage = (currentPage + 1) * pageSize <= totalPage;
            HasPreviousPage = currentPage > 1;
        }
    }
}
