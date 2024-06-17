using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int Id { get; set; }

    }
}
