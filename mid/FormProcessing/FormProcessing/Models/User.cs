using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormProcessing.Models
{
    public class User
    {
        [Required(ErrorMessage = "Provide name")]
        [StringLength(6, ErrorMessage ="Name atlest 6 char")]
        public string Name { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 8)]
        public string Email { get; set; }
        
    }
}