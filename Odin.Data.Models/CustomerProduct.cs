﻿namespace Odin.Data.Models
{
    public class CustomerProduct
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
