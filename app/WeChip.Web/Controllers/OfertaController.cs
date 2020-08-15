using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeChip.Business.Repositories;
using WeChip.Domain.Entities;
using WeChip.Web.Models;

namespace WeChip.Web.Controllers
{
    public class OfertaController : Controller
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly ProdutoRepository _produtoRepository;
        private readonly OfertaRepository _ofertaRepository;

        public OfertaController(ClienteRepository clienteRepository, ProdutoRepository produtoRepository, OfertaRepository ofertaRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _ofertaRepository = ofertaRepository;
        }

        public IActionResult Index()
        {
            var ofertas = _ofertaRepository.GetAll();

            return View(ofertas);
        }

        public IActionResult Form()
        {
            ViewData["ListCliente"] = new SelectList(_clienteRepository.Search(x => x.StatusAtualId == 1), "Id", "Nome");
            ViewData["Produtos"] = _produtoRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Form(OfertaViewModel model)
        {
            var oferta = new Oferta
            {
                ClienteId = model.ClienteId,
                OfertaProdutos = model.Produtos.Where(x => x.Checked).Select(x => new OfertaProduto {ProdutoId = x.Id}).ToList()
            };

            var cliente = _clienteRepository.GetById(model.ClienteId);
            cliente.StatusAtualId = 3;

            _ofertaRepository.AddOrUpdate(oferta);
            _clienteRepository.AddOrUpdate(cliente);

            return RedirectToAction("Index");
        }
    }
}
