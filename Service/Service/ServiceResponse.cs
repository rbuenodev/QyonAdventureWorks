namespace Service
{
    public abstract class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public bool HasErrors { get; set; } = false;
    }
}
