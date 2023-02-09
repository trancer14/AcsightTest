using AcSight.Core.Common.Abstract;
using AcSight.Core.Common.Concrete;
using AcSight.Core.Models;
using AcSight.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcSight.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IServiceDataResponse<CustomerModel>> Get([FromQuery] PageParameters pageParameters)
        {
            return await _customerService.Get(pageParameters);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IServiceDataResponse<CustomerModel>> Get(int id)
        {
            return await _customerService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IServiceResponse> Post(CustomerModel customer)
        {
            return await _customerService.Insert(customer);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IServiceResponse> Put(CustomerModel customer)
        {
            return await _customerService.Update(customer);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IServiceResponse> Delete(int id)
        {
            return await _customerService.Delete(id);
        }
        
    }
}
