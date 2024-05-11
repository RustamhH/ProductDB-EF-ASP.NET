using Database.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Concretes
{
    public class Product:BaseEntity
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public double? Price { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        public virtual Category? Category { get; set; }
    }
}
