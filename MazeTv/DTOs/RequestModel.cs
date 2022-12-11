namespace MazeTv.DTOs
{
    public class RequestModel
    {
        public RequestModel()
        {
            Skip = 0;
            Take = 10;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
