using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using WeChip.Data;
using WeChip.Domain.Entities;

namespace WeChip.Business.Repositories
{
    public class ProdutoRepository : Repository<Produto>
    {
        public ProdutoRepository(WeChipContext context, ILogger<Repository<Produto>> logger) : base(context, logger)
        {
        }
    }
}
