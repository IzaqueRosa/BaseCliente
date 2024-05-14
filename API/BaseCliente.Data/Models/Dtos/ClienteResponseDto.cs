namespace BaseCliente.Data.Models.Dtos
{
    public class ClienteResponseDto
    {
        public int IdCliente { get; set; }
        public string IdBanco { get; set; }
        public string Banco { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
