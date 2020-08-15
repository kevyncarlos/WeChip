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
    public class ClienteController : Controller
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly StatusRepository _statusRepository;

        public ClienteController(ClienteRepository clienteRepository, StatusRepository statusRepository)
        {
            _clienteRepository = clienteRepository;
            _statusRepository = statusRepository;
        }

        public IActionResult Index()
        {
            var clientes = _clienteRepository.GetAll();

            return View(clientes);
        }

        public IActionResult Form(int? id)
        {
            if (id.HasValue)
            {
                var cliente = _clienteRepository.GetById(id.Value);

                ViewData["Title"] = $"Editar Cliente - {cliente.Nome}";

                var model = new ClienteViewModel
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone,
                    Cpf = cliente.Cpf,
                    Credito = cliente.Credito,
                    StatusAtualId = cliente.StatusAtualId,
                    EnderecoEntrega = new ClienteViewModel.Endereco
                    {
                        Rua = cliente.EnderecoEntrega.Rua,
                        Numero = cliente.EnderecoEntrega.Numero,
                        Bairro = cliente.EnderecoEntrega.Bairro,
                        Complemento = cliente.EnderecoEntrega.Complemento,
                        Cep = cliente.EnderecoEntrega.Cep,
                        Cidade = cliente.EnderecoEntrega.Cidade,
                        Estado = cliente.EnderecoEntrega.Estado
                    }
                };

                return View(model);
            }

            ViewData["Title"] = "Cadastrar Cliente";

            return View();
        }

        [HttpPost]
        public IActionResult Form(ClienteViewModel model)
        {
            var cliente = new Cliente();
            
            if (model.Id != 0)
            {
                cliente = _clienteRepository.GetById(model.Id);
            }

            cliente.Id = model.Id;
            cliente.Nome = model.Nome;
            cliente.Telefone = model.Telefone;
            cliente.Cpf = model.Cpf;
            if (model.Id == 0)
            {
                cliente.Credito = model.Credito;
                cliente.StatusAtualId = 1;
            }

            cliente.EnderecoEntrega ??= new Cliente.Endereco();
            cliente.EnderecoEntrega.Rua = model.EnderecoEntrega.Rua;
            cliente.EnderecoEntrega.Numero = model.EnderecoEntrega.Numero;
            cliente.EnderecoEntrega.Bairro = model.EnderecoEntrega.Bairro;
            cliente.EnderecoEntrega.Complemento = model.EnderecoEntrega.Complemento;
            cliente.EnderecoEntrega.Cep = model.EnderecoEntrega.Cep;
            cliente.EnderecoEntrega.Cidade = model.EnderecoEntrega.Cidade;
            cliente.EnderecoEntrega.Estado = model.EnderecoEntrega.Estado;

            _clienteRepository.AddOrUpdate(cliente);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepository.GetById(id);

            _clienteRepository.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}
