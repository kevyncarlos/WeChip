using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChip.WebAPI.Models
{
    public class Venda
    {
        public int CodOferta { get; set; }
        public int CodStatus { get; set; }
        public int IdProduto { get; set; }
        public string CPF { get; set; }
    }
}
