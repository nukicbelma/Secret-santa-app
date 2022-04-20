using AutoMapper;
using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace secretsantaapp.AutoMapper
{
    public class secretsantaappProfile : Profile
    {
        public secretsantaappProfile()
        {
            CreateMap<UsersSearchRequest, Database.Users>();
            CreateMap<UsersInsertRequest, Database.Users>();
            CreateMap<Database.UsersRoles, Model.Models.UsersRoles>();
            CreateMap<Database.Roles, Model.Models.Roles>();
            CreateMap<Database.Users, Model.Models.Users>();
        }
    }
}
