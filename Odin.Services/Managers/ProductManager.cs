using AutoMapper;
using Odin.BLL.Services;
using Odin.Data.Models;
using Odin.DataAccess.Repositories.Interfaces;
using Odin.Models;
using System.Collections.Generic;

namespace Odin.BLL.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IMapper _mapper;

        private readonly IProductRepository _productRepository;

        public ProductManager(
            IMapper mapper,
            IProductRepository productRepository
        )
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(new Product() { Id = id });
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.Get(x => x.Id == id);

            return _mapper.Map<ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = _productRepository.GetList();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public void Update(ProductDTO productDTO)
        {
            var product = _productRepository.Get(x => x.Id == productDTO.Id);

            var mappedProduct = _mapper.Map(productDTO, product);

            _productRepository.Update(mappedProduct);
        }
    }
}
