namespace Service.HistoricosCorrida.Response
{
    public class HistoricoCorridaResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
