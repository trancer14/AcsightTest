using AcSight.Core.Models;
using AcSight.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Core.Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //User Map
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
            //Customer Map
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();



        }
        
    }
}
