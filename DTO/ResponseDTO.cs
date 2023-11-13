namespace DTO;

public class ResponseDTO<T>
{
    public T? Resultado  { get; set; }
    public bool EstaCorreto { get; set; }
    public string? Mensagem { get; set; }
}
 