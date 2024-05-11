using Database.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Concretes
{
    public class Order:BaseEntity
    {
        public DateTime TimeConfirmed { get; set; } = DateTime.Now;
    }
}
