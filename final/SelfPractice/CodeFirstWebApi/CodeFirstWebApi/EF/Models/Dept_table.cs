using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstWebApi.EF.Models
{
    public class Dept_table
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string DeptName { get; set; }

        [ForeignKey("Student")]
        public int SId { get; set; }
        public virtual Student_table? Student { get; set; }
}
}
