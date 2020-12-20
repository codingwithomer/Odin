using Odin.Core.DataAccess.EntityFramework;
using Odin.Data.Models;
using Odin.DataAccess.Context;
using Odin.DataAccess.Repositories.Interfaces;

namespace Odin.DataAccess.Repositories.Concretes
{
    public class CustomerRepository : EntityFrameworkRepository<Customer, OdinDbContext>, ICustomerRepository
    {
        
    }
}
