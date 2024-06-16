using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail()
        {
            
        }

        public Detail(string description, string title, int categoryId)
        {
            Description = description;
            Title = title;
            CategoryId = categoryId;
        }
        public string Description { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
