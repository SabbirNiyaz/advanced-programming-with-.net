using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstWebApi.EF.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName= "varchar(100)")]
        public string Name { get; set; } 
    }
}
