using CodeFirstWebApi.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebApi.EF
{
    public class CodeFirstContext: DbContext
    {
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options): base(options) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }


    }
}
