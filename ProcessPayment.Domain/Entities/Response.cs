namespace ProcessPayment.Domain.Entities
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string State { get; set; }
        public T Data { get; set; }
    }
}
