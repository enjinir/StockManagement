using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public string OwnerName { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
