namespace BaseCliente.Data.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public int IdBanco { get; set; }

        public required string Nome { get; set; }

        public required string CPF { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
