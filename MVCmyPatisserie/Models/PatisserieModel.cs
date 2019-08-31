using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCmyPatisserie.Models
{
    public class PatisserieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgeUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}