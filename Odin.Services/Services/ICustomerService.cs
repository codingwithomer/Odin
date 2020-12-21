using Odin.Models;
using System.Collections.Generic;

namespace Odin.BLL.Services
{
    public interface ICustomerService
    {
        CustomerDTO GetCustomerById(int id);
        IEnumerable<CustomerDTO> GetCustomers();
        void CreateCustomer(CustomerDTO customerDTO);
        void Delete(int id);
        void Update(CustomerDTO customerDTO);
    }
}
