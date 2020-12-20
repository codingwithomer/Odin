using Odin.Core.DataAccess.EntityFramework;
using Odin.Data.Models;
using Odin.DataAccess.Context;
using Odin.DataAccess.Repositories.Interfaces;

namespace Odin.DataAccess.Repositories.Concretes
{
    public class ProductRepository : EntityFrameworkRepository<Product, OdinDbContext>, IProductRepository
    {

    }
}
