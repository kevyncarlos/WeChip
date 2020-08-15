using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeChip.Business.Repositories;
using WeChip.WebAPI.Models;

namespace WeChip.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly OfertaRepository _ofertaRepository;
        private readonly ILogger<VendaController> _logger;

        public VendaController(OfertaRepository ofertaRepository, ILogger<VendaController> logger)
        {
            _ofertaRepository = ofertaRepository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Venda> Get()
        {
            var vendas = new List<Venda>();

            foreach (var oferta in _ofertaRepository.GetAll())
            {
                foreach (var ofertaProduto in oferta.OfertaProdutos)
                {
                    vendas.Add(new Venda
                    {
                        CodOferta = oferta.Id,
                        CodStatus = oferta.Cliente.StatusAtualId,
                        CPF = oferta.Cliente.Cpf,
                        IdProduto = ofertaProduto.ProdutoId
                    });
                }
            }

            return vendas;
        }
    }
}
