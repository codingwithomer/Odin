using Odin.Models;
using System.Collections.Generic;

namespace Odin.BLL.Services
{
    public interface IProductService
    {
        ProductDTO GetProductById(int id);
        IEnumerable<ProductDTO> GetProducts();
        void CreateProduct(ProductDTO productDTO);
        void Delete(int id);
        void Update(ProductDTO productDTO);
    }
}
