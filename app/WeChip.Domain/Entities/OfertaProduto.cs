using System;
using System.Collections.Generic;
using System.Text;

namespace WeChip.Domain.Entities
{
    public class OfertaProduto : Entity
    {
        public int OfertaId { get; set; }
        public int ProdutoId { get; set; }

        public Oferta Oferta { get; set; }
        public Produto Produto { get; set; }
    }
}
