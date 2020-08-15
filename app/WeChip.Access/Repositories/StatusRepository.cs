using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using WeChip.Data;
using WeChip.Domain.Entities;

namespace WeChip.Business.Repositories
{
    public class StatusRepository : Repository<Status>
    {
        public StatusRepository(WeChipContext context, ILogger<Repository<Status>> logger) : base(context, logger)
        {
        }
    }
}
