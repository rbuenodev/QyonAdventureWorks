namespace Service.Competidores.Response
{
    public class CompetidorResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
