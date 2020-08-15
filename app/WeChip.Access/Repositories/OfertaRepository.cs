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
    public class OfertaRepository : Repository<Oferta>
    {
        private readonly WeChipContext _context;

        public OfertaRepository(WeChipContext context, ILogger<Repository<Oferta>> logger) : base(context, logger)
        {
            _context = context;
        }

        public new IList<Oferta> GetAll()
        {
            return _context.Ofertas
                .Include(x => x.Cliente)
                .Include(x => x.OfertaProdutos).ThenInclude(x => x.Produto)
                .ToList();
        }
    }
}
