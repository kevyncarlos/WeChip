namespace WeChip.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Credito { get; set; }
        public int StatusAtualId { get; set; }

        public Status StatusAtual { get; set; }
        public Endereco EnderecoEntrega { get; set; }

        public class Endereco
        {
            public string Cep { get; set; }
            public string Rua { get; set; }
            public int Numero { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
        }
    }
}
