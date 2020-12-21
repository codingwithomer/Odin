using Microsoft.AspNetCore.Mvc;
using Odin.BLL.Services;
using Odin.Models;
using System.Collections.Generic;

namespace Odin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            return _customerService.GetCustomers();
        }

        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            return _customerService.GetCustomerById(id);
        }

        [HttpPost]
        public void Post([FromBody] CustomerDTO customerDTO)
        {
            _customerService.CreateCustomer(customerDTO);
        }

        [HttpPut("{id}")]
        public void Put(CustomerDTO customerDTO)
        {
            _customerService.Update(customerDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}
