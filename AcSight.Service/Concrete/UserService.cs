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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IServiceResponse> Delete(int userId)
        {
            var response = new ServiceResponse();
            var removed = await _userRepository.FindByIdAsync(userId);

            if (removed == null)
            {
                response.IsSuccessful = false;
                response.Status = 404;
                response.Message.Add("User Not Found!");
                return response;
            }
            else
            {

                try
                {
                    removed.IsActive = false;
                    removed.EditedDate = DateTime.Now;
                    await _userRepository.UpdateAsync(removed);
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

        public async Task<IServiceDataResponse<UserModel>> Get(PageParameters pageParameters)
        {
            var resp = new ServiceDataResponse<UserModel>();
            var data = await _userRepository.GetAllAsync(x => x.IsActive == true);
            if (data.Count() > 0)
            {
                data = data
                .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                   .Take(pageParameters.PageSize).ToList();
                resp.IsSuccessful = true;
                resp.Status = 200;
                resp.Message = "Successful";
                resp.DataList = _mapper.Map<List<UserModel>>(data);
            }
            else
            {
                resp.IsSuccessful = false;
                resp.Status = 400;
                resp.Message = "Not Found";

            }
            return resp;
        }

        public async Task<IServiceDataResponse<UserModel>> GetById(int userId)
        {
            var resp = new ServiceDataResponse<UserModel>();
            var data = await _userRepository.FindByIdAsync(userId);
            if (data != null)
            {
                resp.IsSuccessful = true;
                resp.Status = 200;
                resp.Message = "Successful";
                resp.Data = _mapper.Map<UserModel>(data);
            }
            else
            {
                resp.IsSuccessful = false;
                resp.Status = 400;
                resp.Message = "Not Found";

            }
            return resp;
        }

        public async Task<IServiceResponse> Insert(UserModel user)
        {
            var response = new ServiceResponse();

            try
            {
                var inserted = _mapper.Map<User>(user);
                await _userRepository.AddAsync(inserted);

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

        public async Task<IServiceDataResponse<UserModel>> Login(UserLoginModel user)
        {
            var resp = new ServiceDataResponse<UserModel>();
            var data = await _userRepository.GetAllAsync(x => x.UserName == user.UserName && x.Password == user.Password && x.IsActive == true);

            if (data.Count()>0)
            {
                resp.IsSuccessful = true;
                resp.Status = 200;
                resp.Message = "Successful";
                resp.Data = _mapper.Map<UserModel>(data.FirstOrDefault());
            }
            else
            {
                resp.IsSuccessful = false;
                resp.Status = 400;
                resp.Message = "Not Found";

            }
            return resp;
        }

        public async Task<IServiceResponse> Update(UserModel user)
        {
            var response = new ServiceResponse();

            try
            {
                var updated = _mapper.Map<User>(user);
                updated.EditedDate = DateTime.Now;

                await _userRepository.UpdateAsync(updated);

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
