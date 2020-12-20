using Odin.Core.Entities;

namespace Odin.Data.Models
{
    public abstract class BaseAudit : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
