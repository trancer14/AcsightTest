using AcSight.Core.Common.Abstract;
using AcSight.Core.Common.Concrete;
using AcSight.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Service.Abstract
{
    public interface ICustomerService
    {
        public Task<IServiceDataResponse<CustomerModel>> Get(PageParameters pageParameters);
        public Task<IServiceDataResponse<CustomerModel>> GetById(int customerId);
        public Task<IServiceResponse> Update(CustomerModel customer);
        public Task<IServiceResponse> Insert(CustomerModel customer);
        public Task<IServiceResponse> Delete(int customerId);

    }
}
