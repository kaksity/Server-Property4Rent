namespace Server.Models.General
{
    public class ServiceResponseWithoutData
    {
        public bool Success { get; set; } = false;
        public int StatusCode { get; set; }
        public string Message { get; set; } = null;
    }
}