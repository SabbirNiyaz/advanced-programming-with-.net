using DatabaseAccessLayer.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.EF
{
    public class UMSContext: DbContext
    {
        public UMSContext(DbContextOptions<UMSContext> options): base(options) { }
        public DbSet<Course> Courses { get; set; }
    }
}
