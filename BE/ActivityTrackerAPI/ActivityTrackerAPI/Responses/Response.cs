namespace ActivityTrackerAPI.Responses
{
    public class Response<T>
    {
        public T? Content { get; set; }
        public string? Message { get; set; }
    }
}
