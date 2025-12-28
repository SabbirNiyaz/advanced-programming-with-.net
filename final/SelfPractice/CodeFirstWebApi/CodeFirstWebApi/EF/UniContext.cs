using CodeFirstWebApi.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.EF
{
    public class UniContext: DbContext
    {
        public UniContext(DbContextOptions<UniContext> options) : base(options)
        { }
        public DbSet<Student_table> Students { get; set; }
        public DbSet<Dept_table> Depts { get; set; }
    }
}
