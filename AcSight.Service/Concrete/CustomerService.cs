using AcSight.Core.Common.Abstract;
using AcSight.Core.Common.Concrete;
using AcSight.Core.Models;
using AcSight.Core.Repositories.Abstract;
using AcSight.Data.Entities;
using AcSight.Service.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AcSight.Service.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IServiceResponse> Delete(int customerId)
        {
            var response = new ServiceResponse();
            var removed = await _customerRepository.FindByIdAsync(customerId);

            if (removed == null)
            {
                response.IsSuccessful = false;
                response.Status = 404;
                response.Message.Add("Customer Not Found!");
                return response;
            }
            else
            {

                try
                {
                    removed.IsActive = false;
                    removed.EditedDate = DateTime.Now;
                    await _customerRepository.UpdateAsync(removed);
                    response.IsSuccessful = true;
                    response.Status = 200;
                    response.Message.Add("Successfully Removed!");
                }
                catch (Exception)
                {

                    throw;
                }
            }


            return response;
        }

        public async Task<IServiceDataResponse<CustomerModel>> Get(PageParameters pageParameters)
        {
            var resp = new ServiceDataResponse<CustomerModel>();
            var data = await _customerRepository.GetAllAsync(x => x.IsActive == true);

            if (data.Count() > 0)
            {
                data = data
                    .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                    .Take(pageParameters.PageSize).ToList();
                resp.IsSuccessful = true;
                resp.Status = 200;
                resp.Message = "Successful";
                resp.DataList = _mapper.Map<List<CustomerModel>>(data);
            }
            else
            {
                resp.IsSuccessful = false;
                resp.Status = 400;
                resp.Message = "Not Found";

            }
            return resp;


        }

        public async Task<IServiceDataResponse<CustomerModel>> GetById(int customerId)
        {
            var resp = new ServiceDataResponse<CustomerModel>();
            var data = await _customerRepository.FindByIdAsync(customerId);
            if (data != null)
            {
                resp.IsSuccessful = true;
                resp.Status = 200;
                resp.Message = "Successful";
                resp.Data = _mapper.Map<CustomerModel>(data);
            }
            else
            {
                resp.IsSuccessful = false;
                resp.Status = 400;
                resp.Message = "Not Found";

            }
            return resp;
        }

        public async Task<IServiceResponse> Insert(CustomerModel customer)
        {
            var response = new ServiceResponse();

            try
            {
                var inserted = _mapper.Map<Customer>(customer);

                await _customerRepository.AddAsync(inserted);

                response.IsSuccessful = true;
                response.Status = 200;
                response.Message.Add("Successfully Added!");
                return response;
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Status = 404;
                response.Message.Add("Error! " + e.Message);
                return response;

            }


        }

        public async Task<IServiceResponse> Update(CustomerModel customer)
        {
            var response = new ServiceResponse();

            try
            {
                var updated = _mapper.Map<Customer>(customer);
                updated.EditedDate = DateTime.Now;
                await _customerRepository.UpdateAsync(updated);

                response.IsSuccessful = true;
                response.Status = 200;
                response.Message.Add("Successfully Updated!");
                return response;
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Status = 404;
                response.Message.Add("Error! " + e.Message);
                return response;

            }
        }
    }
}
