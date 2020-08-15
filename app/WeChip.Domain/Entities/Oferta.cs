using System;
using System.Collections.Generic;
using System.Text;

namespace WeChip.Domain.Entities
{
    public class Oferta : Entity
    {
        public int ClienteId { get; set; }
        
        public Cliente Cliente { get; set; }

        public ICollection<OfertaProduto> OfertaProdutos { get; set; }
    }
}
