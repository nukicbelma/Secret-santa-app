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
            CreateMap<GiftInsertRequest, Database.Gift>();
            CreateMap<GiftSearchRequest, Database.Gift>();
            CreateMap<Database.UsersRoles, Model.Models.UsersRoles>();
            CreateMap<Database.Roles, Model.Models.Roles>();
            CreateMap<Database.Users, Model.Models.Users>();
            CreateMap<Database.Gift, Model.Models.Gift>();
        }
    }
}
