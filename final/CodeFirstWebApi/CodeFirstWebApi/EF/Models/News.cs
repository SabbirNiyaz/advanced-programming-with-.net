using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstWebApi.EF.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName= "varchar(100)")]
        public string Title { get; set; }
        public string Date { get; set; }

        [ForeignKey("Cat")]
        public int CId { get; set; }
        public virtual Category Cat { get; set; }  // Create Category class's object

    }
}
