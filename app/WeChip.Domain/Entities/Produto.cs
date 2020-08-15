using WeChip.Domain.Enums;

namespace WeChip.Domain.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public TipoProduto Tipo { get; set; }
        public int CodigoProduto { get; set; }
    }
}
