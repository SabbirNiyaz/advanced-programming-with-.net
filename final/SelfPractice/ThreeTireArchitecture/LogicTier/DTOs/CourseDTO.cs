using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }
    }
}
