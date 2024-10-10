using Domain.Contracts;
using Domain.Models;
using Infrastature.dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastature.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(CURDDbContext dbContext) : base(dbContext)
        {
        }

        public async Task UpdateAsync(Staff staff)
        {
            _context.Update(staff);
            await _context.SaveChangesAsync();
        }
    }
}
