namespace Server.Models.General
{
    public class ServiceReponse<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = null;
        public int StatusCode { get; set; }
        public T Data { get; set; } 
    }
}