namespace MazeTv.DTOs
{
    public class QueryResponse<T>
    {
        public QueryResponse()
        {
            TotalCount = -1;
        }
        public T? Data { get; set; }
        public int TotalCount { get; set; }

    }
}
