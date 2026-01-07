using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.EF
{
    public class DatabaseRepresentContext: DbContext
    {
        public DatabaseRepresentContext(DbContextOptions<DatabaseRepresentContext> options) : base(options) 
        { }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
    }
}
