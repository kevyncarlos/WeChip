using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeChip.Data;
using WeChip.Domain.Entities;

namespace WeChip.Business.Repositories
{
    public class ClienteRepository : Repository<Cliente>
    {
        private readonly WeChipContext _context;

        public ClienteRepository(WeChipContext context, ILogger<Repository<Cliente>> logger) : base(context, logger)
        {
            _context = context;
        }

        public new IList<Cliente> GetAll()
        {
            return _context.Clientes.Include(x => x.StatusAtual).ToList();
        }
    }
}
