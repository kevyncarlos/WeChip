using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using WeChip.Data;

namespace WeChip.Business.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WeChipContext _context;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(WeChipContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> Search(Func<T, bool> filter)
        {
            var query = _context.Set<T>();

            return query.Where(filter).ToList();
        }

        public T AddOrUpdate(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at add or update the object in DB.");
            }

            return entity;
        }

        public T Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at remove the object of DB.");
            }

            return entity;
        }
    }
}
