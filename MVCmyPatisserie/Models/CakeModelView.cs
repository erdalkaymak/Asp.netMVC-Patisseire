using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCmyPatisserie.Models
{
    public class CakeModelView
    {
        public int Id { get; set; }

        [Required]

        [MinLength(3,ErrorMessage ="You should write at least 10 characters")]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public string ImgeUrl { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="You should write Max 100 characters")]
        [MinLength(10,ErrorMessage = "You should write at least 10 characters")]
        public string Description { get; set; }
    }
}