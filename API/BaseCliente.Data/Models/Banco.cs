namespace BaseCliente.Data.Models
{
    public class Banco
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
