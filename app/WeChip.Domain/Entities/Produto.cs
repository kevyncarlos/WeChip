using System.Collections.Generic;
using WeChip.Domain.Enums;

namespace WeChip.Domain.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public TipoProduto Tipo { get; set; }
        public string CodigoProduto { get; set; }

        public ICollection<OfertaProduto> OfertaProdutos { get; set; }
    }
}
