using System;

namespace BaseCliente.Models
{
    public class CwCliente
    {
        public int Id { get; set; }

        public int IdBanco { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}