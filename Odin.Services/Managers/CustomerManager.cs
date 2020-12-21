using AutoMapper;
using Odin.BLL.Services;
using Odin.Data.Models;
using Odin.DataAccess.Repositories.Interfaces;
using Odin.Models;
using System.Collections.Generic;

namespace Odin.BLL.Managers
{
    public class CustomerManager : ICustomerService
    {
        private readonly IMapper _mapper;

        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(
            IMapper mapper,
            ICustomerRepository customerRepository
        )
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public void CreateCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

            _customerRepository.Add(customer);
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(new Customer() { Id = id });
        }

        public CustomerDTO GetCustomerById(int id)
        {
            var customer = _customerRepository.Get(x => x.Id == id);

            return _mapper.Map<CustomerDTO>(customer);
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            var customers = _customerRepository.GetList();

            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public void Update(CustomerDTO customerDTO)
        {
            var customer = _customerRepository.Get(x => x.Id == customerDTO.Id);

            var mappedProduct = _mapper.Map(customerDTO, customer);

            _customerRepository.Update(mappedProduct);
        }
    }
}
