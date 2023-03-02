namespace Service.PistasCorrida.Response
{
    public class PistaCorridaResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
