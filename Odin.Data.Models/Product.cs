using Odin.Core.Entities;

namespace Odin.Data.Models
{
    public class Product : BaseAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
