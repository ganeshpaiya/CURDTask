using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastature.dbcontext
{
    public class CURDDbContext : IdentityDbContext
    {

        public CURDDbContext(DbContextOptions<CURDDbContext> options) : base(options)
        {

        }
        public DbSet<Staff> Staffs { get; set; }
    }
}
