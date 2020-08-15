using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeChip.Web.Models
{
    public class OfertaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int ClienteId { get; set; }
        public Produto[] Produtos { get; set; }

        public class Produto
        {
            public int Id { get; set; }
            public bool Checked { get; set; }
        }
    }
}
