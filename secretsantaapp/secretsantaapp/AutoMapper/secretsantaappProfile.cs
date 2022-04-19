﻿using AutoMapper;
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
            CreateMap<Database.Users, Model.Models.Users>();
        }
    }
}