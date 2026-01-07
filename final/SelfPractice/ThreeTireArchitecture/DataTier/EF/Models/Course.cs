using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.EF.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string CourseName { get; set; }
    }
}
