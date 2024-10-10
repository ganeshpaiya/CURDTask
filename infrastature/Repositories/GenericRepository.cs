using Domain.Common;
using Domain.Contracts;
using Infrastature.dbcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastature.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {

        protected readonly CURDDbContext _context;

        public GenericRepository(CURDDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            var entityadd = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entityadd.Entity;

        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();



        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> contition)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(contition);
        }
    }
}
    

    

