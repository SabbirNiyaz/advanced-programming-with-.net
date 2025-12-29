using CodeFirstWebApi.EF.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstWebApi.DTOs
{
    public class DeptsDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string DeptName { get; set; }

        [Required]
        public int SId { get; set; }
    }
}
