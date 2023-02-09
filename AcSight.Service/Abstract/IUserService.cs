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
    public interface IUserService
    {
        public Task<IServiceDataResponse<UserModel>> Get(PageParameters pageParameters);
        public Task<IServiceDataResponse<UserModel>> GetById(int userId);
        public Task<IServiceDataResponse<UserModel>> Login(UserLoginModel user);

        public Task<IServiceResponse> Update(UserModel user);
        public Task<IServiceResponse> Insert(UserModel user);
        public Task<IServiceResponse> Delete(int userId);
    }
}
