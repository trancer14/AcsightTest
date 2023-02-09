using AcSight.Core.Common.Abstract;
using AcSight.Core.Common.Concrete;
using AcSight.Core.Models;
using AcSight.Data.Entities;
using AcSight.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AcSight.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IServiceDataResponse<UserModel>> Get([FromQuery] PageParameters pageParameters)
        {
            return await _userService.Get(pageParameters);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IServiceDataResponse<UserModel>> Get(int id)
        {
            return await _userService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IServiceResponse> Post(UserModel user)
        {
            return await _userService.Insert(user);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IServiceResponse> Put(UserModel user)
        {
            return await _userService.Update(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IServiceResponse> Delete(int id)
        {
            return await _userService.Delete(id);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IServiceDataResponse<UserModel>> Login([FromBody] UserLoginModel user)
        {
            return await _userService.Login(user);
        }
    }
}
