using ECommerce.Domain.Common;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            
        }

        public Category(string name, int parentId, int priority)
        {
            Name = name;
            ParentId = parentId;
            Priority = priority;
        }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Priority { get; set; }

        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
