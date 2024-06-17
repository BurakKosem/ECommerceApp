using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class CategoryProduct : EntityBase
    {
        public CategoryProduct()
        {
            
        }

        public CategoryProduct(int categoryId, int productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
