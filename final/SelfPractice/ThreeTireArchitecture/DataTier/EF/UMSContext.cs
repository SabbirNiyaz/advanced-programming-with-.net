using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.EF
{
    public class UMSContext: DbContext
    {
        public UMSContext(DbContextOptions<UMSContext> options) : base(options)
        {
        }
        public DbSet<Models.Course> Courses { get; set; }
    }
}
