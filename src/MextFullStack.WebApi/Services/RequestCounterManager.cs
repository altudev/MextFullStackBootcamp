namespace MextFullStack.WebApi.Services
{
    public class RequestCounterManager
    {
        private int TotalCount { get; set; }

        public RequestCounterManager()
        {
            TotalCount = 0;
        }

        public void Increment()
        {
            TotalCount++;
        }

        public int GetTotalCount()
        {
            return TotalCount;
        }
    }
}
