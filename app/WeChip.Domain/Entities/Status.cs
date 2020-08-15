using System.Collections.Generic;

namespace WeChip.Domain.Entities
{
    public class Status : Entity
    {
        public string Descricao { get; set; }
        public bool FinalizaCliente { get; set; }
        public bool ContabilizaVenda { get; set; }
        public string CodigoStatus { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
