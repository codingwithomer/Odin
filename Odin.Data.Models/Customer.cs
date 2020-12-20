using System.Collections.Generic;

namespace Odin.Data.Models
{
    public class Customer : BaseAudit
    {
        public string TCIdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
